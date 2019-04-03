import { Observable } from "rxjs/Rx";
import { IUserService } from "./iuserService";
import { Http, RequestOptions, Headers, Response } from "@angular/http";
import { User } from "./user";
import { Injectable } from "@angular/core";

@Injectable()
export class UserService implements IUserService{
    
    private urlUser: string = `http://localhost:85/api/users`;
    private headers = new Headers({'Accept': 'application/json', 'Content-Type': 'application/json'});
    private options = new RequestOptions({headers: this.headers});

    constructor(private http: Http) { }
    public getUsers(): Observable<User[]> {
        let users = this.http.get(this.urlUser, this.options).map(this.extractData).catch(this.handleError);
        return users;
    }
    private handleError(error: Response | any){
        console.error(error);
        return Observable.throw(error.json().error || 'Server Error');
    }
    private extractData(res: Response){
        let body = res.json();
        return body;
    }

    public addUser(user: User): Observable<User>{
        return this.http.post(this.urlUser, user, this.options).map(this.extractData).catch(this.handleError);
    }

    public updateUser(userId: number, user: User): Observable<User>{
        let url = `http://localhost:85/api/users/${userId}`;
        return this.http.put(url, JSON.stringify(user), this.options).map(this.extractData).catch(this.handleError);
    }

    public deleteUser(userId: number): Observable<User>{
        let url = `http://localhost:85/api/users/${userId}`;
        return this.http.delete(url, this.options).map(this.extractData).catch(this.handleError);
    }
}