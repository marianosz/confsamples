///<reference path='/typings/node/node.d.ts'/>

import { createServer } from 'http';

export function simpleServer(port: number, message: string) {

    createServer((req, res) => {
		res.writeHead(200, { 'Content-Type':'text/html' });
        res.write('<h1>' + message + '</h1>');
        res.end()
    }).listen(port);
}