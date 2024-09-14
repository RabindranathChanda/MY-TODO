import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { TodoDetails } from './todo-details.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class TodoDetailsService {

  url:string = environment.apiBaseUrl +'/Todo'
  list:TodoDetails[] = [];
  formData : TodoDetails = new TodoDetails()
  formSubmited:boolean = false;
  constructor(private http:HttpClient) { }

  refreshTodoList(){
    this.http.get(this.url).subscribe({
      next:res =>{
        this.list = res as TodoDetails[]
      },
      error:err => {
        console.log(err)
      }
    })
  }

  postTodoDetals(){
    return this.http.post(this.url, this.formData)
  }

  putTodoDetals(){
    return this.http.put(this.url+'/'+this.formData.todoId, this.formData)
  }

  deleteTodoDetals(id: number){
    return this.http.delete(this.url+'/'+id)
  }

  resetForm(form:NgForm){
    form.form.reset()
    this.formData = new TodoDetails()
    this.formSubmited = false;
  }

}
