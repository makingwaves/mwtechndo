class HelloWorld extends React.Component {

    constructor(props) {
        super(props);
        fetch('/account/getAccessToken')      
            .then(response => response.json())
            .then(accessToken => {
                fetch('https://localhost:44377/api/values?name=wilis', { 
                    crossDomain: true,
                    method: 'get', 
                    headers: new Headers({
                      'Authorization': 'Bearer ' + accessToken
                    })
                  })
                  .then(response => response.text())
                  .then(text => alert(text));
            });
    }

    render() {
        return <div>Hello World!!</div>;
    }
}

const containerElement = document.getElementById('content');
ReactDOM.render(<HelloWorld />, containerElement);