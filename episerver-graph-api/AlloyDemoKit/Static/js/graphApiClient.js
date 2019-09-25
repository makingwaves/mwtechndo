function getGraphAPIData(graphApiUrl, accessToken, functionToBuildHtml) {
    fetch(graphApiUrl, {
        method: 'GET',
        mode: 'cors',
        headers: {
            'Authorization': 'Bearer ' + accessToken,
            'Content-Type': 'application/json'
        }
    })
    .then(response => response.json())
    .then(graphApiJson => {
        functionToBuildHtml(graphApiJson);
    });
};