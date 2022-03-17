import * as React from 'react';
import axios from "axios";
function  App() {
    
    axios({

        // Endpoint to send files
        url: "https://localhost:44386/weatherforecast",
        method: "GET",
    }).then(data => { debugger });  //**!!

    return (
		<div>{'react setup from scratch without cra testing ts'}</div>
	);
}
export default App;