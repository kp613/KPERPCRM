import { LoggedUser } from "./loggedUser";


export class UserParams {
  gender: string;
  minAge = 18;
  maxAge = 99;
  pageNumber = 1;
  pageSize = 5;
  orderBy = 'lastActive';

  constructor(user: LoggedUser) {
    this.gender = user.gender === 'female' ? 'male' : 'female';
  }
}
