// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const buttonToAddTeam = document.getElementById("SwitchTeamType");
const selectTeamWrapper = document.getElementById('SelectTeamWrapper');

if (buttonToAddTeam && selectTeamWrapper) {
    buttonToAddTeam.addEventListener('click', (e) => {
        let selectTeamInput = document.getElementById('SelectTeamInput');
        if (selectTeamInput.tagName === 'SELECT') {
            let alterTeamInput = document.createElement('input');

            alterTeamInput.setAttribute('type', 'text');
            alterTeamInput.setAttribute('name', 'team');
            alterTeamInput.setAttribute('placeholder', 'Введите команду..');
            alterTeamInput.setAttribute('id', 'SelectTeamInput');
            alterTeamInput.setAttribute('maxLength', '32');
            alterTeamInput.required = true;

            selectTeamWrapper.replaceChild(alterTeamInput, selectTeamInput);
            buttonToAddTeam.remove();

        }
    });
}

const tableWithPlayers = document.getElementById("tableWithPlayers");

if (tableWithPlayers) {
    var connection = new signalR.HubConnectionBuilder().withUrl("/playerHub").build();
    connection.start()
        .catch(e => console.log(e.toString()));

    connection.on("ReceivePlayerUpdate", function (player) {
        tableWithPlayers.insertAdjacentHTML("beforeend",
            `<tr class="players-container__table-row">
                <td class="players-container__table-data">${player.id}</td>
                <td class="players-container__table-data">${player.name}</td>
                <td class="players-container__table-data">${player.surname}</td>
                <td class="players-container__table-data">${player.gender}</td>
                <td class="players-container__table-data">${new Date(player.birthDate).toLocaleDateString('ru-RU')}</td>
                <td class="players-container__table-data">${player.team}</td>
                <td class="players-container__table-data">${player.country}</td>
                <td class="players-container__table-data"><div><a href="/Players/Edit/${player.id}">Редактировать</a></div></td>
            </tr>`
        );

        let tdPlayersNotExists = document.getElementById("tdPlayersNotExists");
        if (tdPlayersNotExists)
            tdPlayersNotExists.parentElement.removeChild(tdPlayersNotExists);
    });
}