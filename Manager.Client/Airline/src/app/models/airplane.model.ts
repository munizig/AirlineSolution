export class Airplane {

    id: string;
    code: string;
    modelId: string;
    passengersQuantity: number;
    createDateLog: string;

    constructor(id: string,
        code: string,
        modelId: string,
        passengersQuantity: number,
        createDateLog: string) {

        this.id = id;
        this.code = code;    
        this.modelId = modelId;
        this.passengersQuantity = passengersQuantity;
        this.createDateLog = createDateLog;
    }

}
