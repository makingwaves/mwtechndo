
fetch("http://localhost/EpiServer.AlloyDemo.GraphAPI/account/getaccesstoken")
    .then(response => response.json())
    .then(accessToken => {
        return fetch("https://graph.microsoft.com/v1.0/me/", {
            method: 'GET',
            mode: 'cors',
            headers: {
                'Authorization': 'Bearer ' + accessToken,
                'Content-Type': 'application/json'
            }
        });
    })
    .then(response => response.json())
    .then(graphApiJson => {
        buildItem(graphApiJson);
    });


function buildItem(graphApiJson) {
    var divPlaceholder = document.getElementById("placeholder1");

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

    divPlaceholder.appendChild(document.createElement('br'));
    divPlaceholder.appendChild(imageIcon);
    divPlaceholder.appendChild(document.createElement('br'));
    divPlaceholder.appendChild(spanTitle);
    divPlaceholder.appendChild(document.createElement('br'));
    divPlaceholder.appendChild(spanDisplayName);
    divPlaceholder.appendChild(document.createElement('br'));
    divPlaceholder.appendChild(spanJobTitle);
    divPlaceholder.appendChild(document.createElement('br'));
    divPlaceholder.appendChild(spanMail);
    divPlaceholder.appendChild(document.createElement('br'));
    divPlaceholder.appendChild(spanOfficeLocation);
    divPlaceholder.appendChild(document.createElement('br'));
    divPlaceholder.appendChild(spanPhone);
}