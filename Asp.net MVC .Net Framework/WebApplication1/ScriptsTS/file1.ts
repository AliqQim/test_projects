

let promiseResolve = null;

function promiser(): Promise<string> {
    console.log("before creating promise");
    let res = new Promise<string>((resolve) => {
        console.log("inside the promise callback");
        promiseResolve = resolve;
    });
    console.log("after creating promise");
    return res;
}

async function f() {
    setTimeout(()=>doResolve(), 1000);

    console.log("before awaiting");
    var value = await promiser();
    console.log("awaited value is:" + value);

}

function doResolve() {
    promiseResolve("the promised string value");
}

f();