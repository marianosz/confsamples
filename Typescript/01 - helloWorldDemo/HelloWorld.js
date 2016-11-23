var HelloWorld = (function () {
    function HelloWorld(message) {
        this.message = message;
    }
    HelloWorld.prototype.sayHello = function () {
        return "Hello " + this.message;
    };
    return HelloWorld;
}());
var hw = new HelloWorld("MUG");
console.log(hw.sayHello());
//# sourceMappingURL=HelloWorld.js.map