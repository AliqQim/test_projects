DoIt();

function DoIt() {
    var client = new MyTestServiceName.Client("https://localhost:44354/");
    var res = client.weatherForecast(3, 4);
}