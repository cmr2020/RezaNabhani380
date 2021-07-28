﻿using MyRezaNabhani.DataLayer.Context;
using MyRezaNabhani.DomainClasses.Permissions;
using MyRezaNabhani.DomainClasses.User;
using MyRezaNabhani.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRezaNabhani.Services.Services
{
    public class PermissionRepository : IPermissionRepository
    {
        private MyRezaNabhaniDbContext _db;

        public PermissionRepository(MyRezaNabhaniDbContext db)
        {
            _db = db;
        }

        public void AddPermissionsToRole(int roleId, List<int> permission)
        {
            foreach (var p in permission)
            {
                _db.RolePermission.Add(new RolePermission()
                {
                    PermissionId = p,
                    RoleId = roleId
                });
            }

            _db.SaveChanges();
        }

        public int AddRole(Role role)
        {
            _db.Roles.Add(role);
            _db.SaveChanges();
            return role.RoleId;
        }

        public void AddRolesToUser(List<int> roleIds, int userId)
        {
            foreach (int roleId in roleIds)
            {
                _db.UserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }

            _db.SaveChanges();
        }

        public bool CheckPermission(int permissionId, string userName)
        {
            int userId = _db.Users.Single(u => u.UserName == userName).UserId;

            List<int> UserRoles = _db.UserRoles
                .Where(r => r.UserId == userId).Select(r => r.RoleId).ToList();

            if (!UserRoles.Any())
                return false;

            List<int> RolesPermission = _db.RolePermission
                .Where(p => p.PermissionId == permissionId)
                .Select(p => p.RoleId).ToList();

            return RolesPermission.Any(p => UserRoles.Contains(p));

        }

      

        public void DeleteRole(Role role)
        {
            role.IsDelete = true;
            UpdateRole(role);

        }

        public void EditRolesUser(int userId, List<int> rolesId)
        {
            //Delete All Roles User
            _db.UserRoles.Where(r => r.UserId == userId).ToList().ForEach(r => _db.UserRoles.Remove(r));

            //Add New Roles
            AddRolesToUser(rolesId, userId);
        }

        public List<Permission> GetAllPermission()
        {
            return _db.Permission.ToList();
        }

        public Role GetRoleById(int roleId)
        {
            return _db.Roles.Find(roleId);
        }

        public List<Role> GetRoles()
        {
            return _db.Roles.ToList();
        }

        public List<int> PermissionsRole(int roleId)
        {
            return _db.RolePermission
                  .Where(r => r.RoleId == roleId)
                  .Select(r => r.PermissionId).ToList();
        }

        public void UpdatePermissionsRole(int roleId, List<int> permissions)
        {
            _db.RolePermission.Where(p => p.RoleId == roleId)
                   .ToList().ForEach(p => _db.RolePermission.Remove(p));

            AddPermissionsToRole(roleId, permissions);
        }

        public void UpdateRole(Role role)
        {
            _db.Roles.Update(role);
            _db.SaveChanges();
        }

       


        }

    }


