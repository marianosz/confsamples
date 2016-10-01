function point(x: number, y:number){
    return {x, y}
}

let p = point(10, 20);
//let x = p.x;
//let y = p.y;

let {x, y} = point(20, 30);

let a = [1,2,3,4,5];

let [first,...rest] = a;
let b = [first, ...rest, first, ...rest];

for (var n of b){
    console.log(n);
}

function greeting(name: string, points: number) {
    return `Hello ${name}! You have ${points} points!`;
}

function displayName(name: string | string[]) {
    if (typeof name === "string") {
		var theString = name;
    }
    else {
		var theStringArray = name;
    }
}
