
export interface ILoggedUser {
  username: string;
  // email: string;  //如果用Email，则knownas不能被注册，原因不明
  name: string;
  token: string;
  profilePicture: string;
  knownAs: string;
  gender: string;
  roles: string[];
}
