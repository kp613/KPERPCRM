import { ILoggedUser } from "./loggedUser";


export class UserParams {
  gender: string;
  minAge = 18;
  maxAge = 90;
  pageNumber = 1;
  pageSize = 6;
  orderBy = 'lastActive';

  constructor(user: ILoggedUser) {
    this.gender = user.gender === 'female' ? 'male' : 'female';
  }
}
