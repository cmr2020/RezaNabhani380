var chatterName = "Visitor";

//Initialize SignalR
var connection = new signalR.HubConnectionBuilder()
    .withUrl('/chatHub')
    .build();

connection.on('ReciveMessage', renderMessage);

connection.start();


function ready() {
    var chatForm = document.getElementById('chatForm');
    chatForm.addEventListener('submit',
        function (e) {
            e.preventDefault();
            var text = e.target[0].value;
            e.target[0].value = '';
            sendMessage(text);
        });
}

function sendMessage(text) {
    if (text && text.length) {
        connection.invoke('SendMessage', chatterName, text);
    }
}

function renderMessage(name, time, message) {
    var nameSpan = document.createElement('span');
    nameSpan.className = 'name';
    nameSpan.textContent = name;

    var timeSpan = document.createElement('span');
    timeSpan.className = 'time';
    var timeFriendly = moment(time).format('H:mm');
    timeSpan.textContent = timeFriendly;

    var headerDiv = document.createElement('div');
    headerDiv.appendChild(nameSpan);
    headerDiv.appendChild(timeSpan);

    var messageDiv = document.createElement('div');
    messageDiv.className = 'message';
    messageDiv.textContent = message;

    var newItem = document.createElement('li');
    newItem.appendChild(headerDiv);
    newItem.appendChild(messageDiv);

    var chatHistory = document.getElementById('chatHistory');
    chatHistory.appendChild(newItem);
    chatHistory.scrollTop = chatHistory.scrollHeight - chatHistory.clientHeight;
}


document.addEventListener('DOMContentLoaded', ready);