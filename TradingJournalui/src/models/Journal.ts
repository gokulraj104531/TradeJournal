export interface Journal{
    journalId:number,
    UserName:string,
    StockName:string,
    OrderType:string,
    Quantity:number,
    EntryPrice:number,
    EntryTime:Date;
    ClosePrice:number,
    CloseTime:Date,
    ProfitorLoss:number,
    JournalTrade:string
}
