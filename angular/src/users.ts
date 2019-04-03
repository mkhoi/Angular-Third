import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { User } from "./user";
import { UserService } from "./userService";
import { Router } from "@angular/router";

@Component({
    selector: "users",
    templateUrl: "src/users.html"
})
export class Users implements OnInit {
    public ngOnInit(): void {
        this.getUsers();
    }
    private users: Observable<User[]>;
    constructor(private userService: UserService, private router: Router) {
        
    }
    /*constructor(){
        let users: Array<any> = [
            {id: 1, firstName: "Ruby", lastName:"Rails", userName: "RubyRails"},
            {id: 2, firstName: "Su", lastName: "Kem", userName: "SuKem"}
        ];
        this.users = users;
    }*/
    
    private getUsers(): void {
        this.users = this.userService.getUsers();
    }

    public onEditClicked(userId: number){
        this.router.navigate(["editUser", userId]);
    }

}