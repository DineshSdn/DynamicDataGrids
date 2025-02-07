import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';


@Injectable({
  providedIn: 'root'
})
export class GetdataService {


  getdataurl:string="http://localhost:7027/api/DynamicDataGrid/GetDynamicDataGridList?id=0"
  
  getdataby_idurl:string="http://localhost:7027/api/DynamicDataGrid/GetDynamicDataGridList?id"
  postandpturl:string="http://localhost:7027/api/DynamicDataGrid/CreateNewDynamicGrid";
  getgriddataurl:string="http://localhost:7027/api/DynamicDataGrid/GetDgFieldList?id";

  postfieldurl:string="http://localhost:7027/api/DynamicDataGrid/CreateNewDgField";
  delete_dg_fields_withid_url="http://localhost:7027/api/DynamicDataGrid/DeleteDgField?id=";
  postresponse_url="http://localhost:7027/api/DynamicDataGrid/CreateNewFieldResponse";


  getresponsebasedonidurl="http://localhost:7027/api/DynamicDataGrid/GetDynamicResponse?fieldid="


countrespnseurl="http://localhost:7027/api/DynamicDataGrid/GetDynamicResponse?fieldid="
update_detaild_sort_order_url="http://localhost:7027/api/DynamicDataGrid/UpdateDetailSortOrder";
update_horizontal_sort_order_url="http://localhost:7027/api/DynamicDataGrid/UpdateHorizontalSortOrder";



healthprofile_url="http://localhost:7027/api/DynamicDataGrid/GetDgHealthProfileGrids";
getdataofgrid_url="http://localhost:7027/api/DynamicDataGrid/";


post_response_url="http://localhost:7027/api/DynamicDataGrid/responseofuser";
Get_response_url="http://localhost:7027/api/DynamicDataGrid?get_grid_Id";


post_option_url="http://localhost:7027/api/DynamicDataGrid/postoption";
get_option_byid_url="http://localhost:7027/api/DynamicDataGrid/All option?QuestionId"

post_Calculation_url="http://localhost:7027/api/DynamicDataGrid/CreateNewCalculation";

get_formula_url="http://localhost:7027/api/DynamicDataGrid/formula_by_field_id?field_id";
delete_response_url="http://localhost:7027/api/DynamicDataGrid/DeleteResponse?id";

get_options_tomyform_url="http://localhost:7027/api/DynamicDataGrid/GetDynamicDataGridMasterData";





  constructor(private http:HttpClient) 
  { }

  getdata():Observable<any>
  {
    return this.http.get<any>(this.getdataurl);
  }
  getdatabyid(id:any):Observable<any>
  {
    return this.http.get<any>(this.getdataby_idurl+"="+id);
  }
  putpost(req:any):Observable<any>
  {
    return this.http.post<any>(this.postandpturl, req);
  }



  // =0&grid_id=3

  getgrid(id:any,grid_id:any):Observable<any>
  {
    return this.http.get<any>(this.getgriddataurl+"="+id+"&grid_id="+grid_id);
  }


  postfield(res:any):Observable<any>
  {
    return this.http.post<any>(this.postfieldurl, res);
  }
  
  delete_dg_fields(id:any):Observable<any>
  {
  return this.http.get<any>(this.delete_dg_fields_withid_url+id);
  }

  postresponse(data:any):Observable<any>
  {
    return this.http.post<any>(this.postresponse_url, data);
  }
  getdataresponse(id:any):Observable<any>
  {
    return this.http.get<any>(this.getresponsebasedonidurl+id);
  }


  getcount():Observable<any>
  {
    return this.http.get<any>(this.countrespnseurl+0);
  }
  
  updatesort_order(order: any[]):Observable<any>
  {
     return this.http.post<any>(this.update_detaild_sort_order_url, order);  
  }


  updatesort_horizontal_order(order: any[]):Observable<any>
  {
    debugger
     return this.http.post<any>(this.update_horizontal_sort_order_url, order);  
  }


  health_profile():Observable<any>
  {
         return this.http.get<any>(this.healthprofile_url);
  }


  getgriddatabyid(id:any):Observable<any>
  {
    return this.http.get(this.getdataofgrid_url+id);
  }

  post_response(res:any):Observable<any>
  {
     return this.http.post(this.post_response_url,res);
  }


  get_response(id:any):Observable<any>
  {
    return this.http.get(this.Get_response_url+"="+id);
  }


  post_option(req:any):Observable<any>
  {
    return this.http.post(this.post_option_url,req);
  }

  get_option_by_id(id:any):Observable<any>
  {
    return this.http.get(this.get_option_byid_url+"="+id);
  }

  post_calculation(req:any):Observable<any>
  {
    return this.http.post(this.post_Calculation_url, req);
  }

  get_formula(field_id:any):Observable<any>
  {
    return this.http.get(this.get_formula_url+"="+field_id)
  }


  Delete_response(id:any):Observable<any>
  {
    return this.http.get<any>(this.delete_response_url+"="+id);
  }

  get_options():Observable<any>
  {
  return this.http.get<any>(this.get_options_tomyform_url);
  }

}
