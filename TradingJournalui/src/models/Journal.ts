export interface Journal{
    journalId:string,
    Username:string,
    StockName:string,
    OrderType:string,
    Quantity:number,
    EntryPrice:number,
    EntryTime:Date;
    ClosePrice:number,
    ProfitorLoss:number,
    JournalTrade:string
}