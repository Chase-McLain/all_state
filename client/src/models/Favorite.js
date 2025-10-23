


export class Favorite{
  constructor(data){
    this.id = data.id
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.recipeId = data.recipeId
    this.accountId = data.accountId
  }
}










