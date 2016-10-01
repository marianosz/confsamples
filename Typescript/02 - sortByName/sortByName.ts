
interface IEntity {
	name: string;
	price: number;
	inStock?: boolean;
}

var e: Entity = {
    name: "Destornillador",
    price: 10,
    isStock: true,
};

class Product implements IEntity {
	constructor(id: number, name:string, price: number) {
		this.id = id
		this.name = name;
		this.price = price;
	}
	id: number;
	name: string;
	price: number;
}

function sortByName(a: IEntity[]) {
	var result = a.slice(0);

	result.sort((a, b) => {
		return a.name.localeCompare(b.name);
    });

    return result;
}

function sortByNameG<T extends IEntity>(a: T[]) {
	var result = a.slice(0);

	result.sort((a, b) => {
		return a.name.localeCompare(b.name);
    });

    return result;
}

var productsT = [
	new Product(10,'Hammer',200),
	new Product(11,'Lawnmover',45),
	new Product(12,'Toaster',35),
	new Product(13,'LED Monitor',40)
];

var r = sortByNameG(productsT);

var firstId = r[0].id
