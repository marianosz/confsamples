function getStringFromWebServerAsync(url: string) {
    return new Promise<string>((resolve, reject) => {
        // note: could be written `$.get(url).done(resolve).fail(reject);`,
        //       but I expanded it out for clarity
        $.get(url).done((data) => {
            resolve(data);
        }).fail((err) => {
            reject(err);
        });
    });
}

async function asyncExample() { 
    try {
        let data = await getStringFromWebServerAsync("http://localhost/GetAString");
        console.log(data);
    }
    catch (err) {
        console.log(err);
    }
}

asyncExample();