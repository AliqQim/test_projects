import * as React from 'react';
import axios from "axios";

let loaded = false;
function  App() {
    const [value, setValue] = React.useState("Loading...");

    if (!loaded) {
        axios({

            // Endpoint to send files
            url: "https://localhost:44386/weatherforecast",
            method: "GET",
        }).then(data => setValue(JSON.stringify(data, null, 4)));
        loaded = true;
    }
    

    return (
		<pre>{value}</pre>
	);
}
export default App;