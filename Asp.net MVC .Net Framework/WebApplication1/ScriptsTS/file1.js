var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
let promiseResolve = null;
function promiser() {
    console.log("before creating promise");
    let res = new Promise((resolve) => {
        console.log("inside the promise callback");
        promiseResolve = resolve;
    });
    console.log("after creating promise");
    return res;
}
function f() {
    return __awaiter(this, void 0, void 0, function* () {
        setTimeout(() => doResolve(), 1000);
        console.log("before awaiting");
        var value = yield promiser();
        console.log("awaited value is:" + value);
    });
}
function doResolve() {
    promiseResolve("the promised string value");
}
f();
