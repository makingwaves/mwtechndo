
function initWidget1(accessToken) {
    fetch("https://graph.microsoft.com/v1.0/me/", {
        method: 'GET',
        mode: 'cors',
        headers: {
            'Authorization': 'Bearer ' + accessToken,
            'Content-Type': 'application/json'
        }
    })
    .then(response => response.json())
    .then(graphApiJson => {
        buildItem(graphApiJson);
    });
};



function buildItem(graphApiJson) {
    var divPlaceholder = document.getElementById("placeholder1");

    var divMain = document.createElement('div');
    divMain.classList.add("mainDiv");

    var imageIcon = document.createElement('i');
    imageIcon.classList.add("material-icons");
    imageIcon.innerHTML = "face";

    var spanTitle = document.createElement('span');
    spanTitle.innerHTML = "<b>Widget 1</b>";

    var spanDisplayName = document.createElement('span');
    spanDisplayName.innerHTML = graphApiJson.displayName;

    var spanPhone = document.createElement('span');
    spanPhone.innerHTML = graphApiJson.businessPhones[0];

    var spanJobTitle = document.createElement('span');
    spanJobTitle.innerHTML = graphApiJson.jobTitle;

    var spanMail = document.createElement('span');
    spanMail.innerHTML = graphApiJson.mail;

    var spanOfficeLocation = document.createElement('span');
    spanOfficeLocation.innerHTML = graphApiJson.officeLocation;

    divMain.appendChild(document.createElement('br'));
    divMain.appendChild(imageIcon);
    divMain.appendChild(document.createElement('br'));
    divMain.appendChild(spanTitle);
    divMain.appendChild(document.createElement('br'));
    divMain.appendChild(spanDisplayName);
    divMain.appendChild(document.createElement('br'));
    divMain.appendChild(spanJobTitle);
    divMain.appendChild(document.createElement('br'));
    divMain.appendChild(spanMail);
    divMain.appendChild(document.createElement('br'));
    divMain.appendChild(spanOfficeLocation);
    divMain.appendChild(document.createElement('br'));
    divMain.appendChild(spanPhone);

    divPlaceholder.appendChild(divMain);

    initDrag(divMain);
}