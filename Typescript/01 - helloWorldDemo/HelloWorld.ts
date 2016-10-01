class HelloWorld {
    message: string;
    constructor(message: string) {
        this.message = message;
    }
    
    sayHello() {
        return "Hello World!" + this.message;
    }
}

var hw = new HelloWorld(" from .NET Conf UY");
console.log(hw.sayHello());

//alert(hw.sayHello());