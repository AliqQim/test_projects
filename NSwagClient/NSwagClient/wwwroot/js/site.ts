DoIt();

function DoIt() {
    var client = new MyTestServiceName.Client("https://localhost:44354/");
    client.weatherForecast(3, 4)
        .then((res: number)=> alert(res));
}