export class Airplane {

    id: string;
    code: string;
    model: string;
    passengersQuantity: number;
    createDateLog: string;

    constructor(id: string,
        code: string,
        model: string,
        passengersQuantity: number,
        createDateLog: string) {

        this.id = id;
        this.code = code;    
        this.model = model;
        this.passengersQuantity = passengersQuantity;
        this.createDateLog = createDateLog;
    }

}
