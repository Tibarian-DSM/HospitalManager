 export interface  MedicFormMod
 {    
    firstName:string,
    lastName:string,
    email:string,
    password:string,
    service_Id:number,
    speciality:string,
    contract:string,
    hireDate:Date,
    contractEnd:Date | null,
    inami:string,
    is_Subsized:boolean
 }