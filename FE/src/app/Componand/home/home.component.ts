import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { GetdataService } from 'src/app/getdata.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  i: number = 2;
  j: number = 0;
  data: any[] = [];
  name: any = false;
  Obj1: Object | undefined
  options_data:any;

  loaderStatus: boolean = true;
  type_name: any = "tabular";
  dynamicGridForm!: FormGroup;
  status: boolean = true;
  displayModal: any = false;

  updatedid: number = 0;
  typeOptions: any[] = [
    { label: 'Tabular', value: '1' },
    { label: 'Multi-Line', value: '2' }
  ];
  statusOptions: any[] = [
    { label: 'Active', value: true },
    { label: 'Disabled', value: false }
  ];
  constructor(private service: GetdataService, private fb: FormBuilder, private route: Router) {

  } ngOnInit(): void {
    this.dynamicGridForm = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      description: ['', Validators.required],
      show_health_profile: [],
      type: [],
      active: [],
      code_key: ['1'],
      created_by: [],
      masterDgTypes: ['Null']
    });



    this.getdata();
    //this.getdata2();

  }
  get_options()
  {
     this.service.get_options()
     .subscribe({
      next:(Response:any)=>
      {
        this.options_data=Response;
      }
     })
  }


  getdata2() {
    console.log(this.i);
    console.log(this.j);
    this.Obj1 = this.i;
    let s1 = this.Obj1.toString();
    this.j = parseInt(s1, 10);
    console.log(this.j);
  }
  getdata() {
    this.service.getdata()
      .subscribe({
        next: (Response: any) => {
          this.data = Response;
        }
      })
  }
  newDynamicGridModal(str: any) {
    this.dynamicGridForm.controls['id'].setValue(str.id);
    this.dynamicGridForm.controls['name'].setValue(str.head_name);
    this.dynamicGridForm.controls['description'].setValue(str.description);
    this.dynamicGridForm.controls['show_health_profile'].setValue(str.show_health_profile);

    this.dynamicGridForm.controls['type'].setValue(str.name.value);
    this.dynamicGridForm.controls['active'].setValue(str.active);
    this.dynamicGridForm.controls['code_key'].setValue(str.code_key);
    this.dynamicGridForm.controls['created_by'].setValue(str.created_by);
    // this.dynamicGridForm.controls['head_name'].setValue(str.head_name);
    if (str.name === "Tabular") {
      this.dynamicGridForm.get('type')?.setValue('1');
    }
    else {
      this.dynamicGridForm.get('type')?.setValue('2');
    }

  }

  viewDataGrid(str: any) {
    this.route.navigate(['/view2'], { queryParams: { id: str.id , grid_type_id:str.type } });
    console.log(str);
  }

  getvalue(value: any) {
    console.log(value)
  }

  showModalDialog() {
    this.displayModal = true;
  }


  okok() {
    alert("Hlllo")
  }
  openModal(res: any) {
this.get_options();
    this.dynamicGridForm = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      description: ['', Validators.required],
      show_health_profile: [],
      type: [Validators.required],
      active: [Validators.required],
      code_key: ['1'],
      created_by: [],
      masterDgTypes: ['Null']
    });
  }

  parameter: boolean = false;


  get_codekey(name:any)
  {
    const modifiedString = name.replace(/ /g, '_').toLowerCase();
    return modifiedString;
  }
  onSubmit(): void {

    if (this.dynamicGridForm.value.name === " ") {

    }
    console.log(this.dynamicGridForm.value);

    if (this.dynamicGridForm.value.active == "true" || this.dynamicGridForm.value.active == true) {
      this.parameter = true;
    }
    else {
      this.parameter = false;
    }

    const data = {

      id: this.dynamicGridForm.value.id,
      name: this.dynamicGridForm.value.name,
      description: this.dynamicGridForm.value.description,
      show_health_profile: this.dynamicGridForm.value.show_health_profile,
      type: parseInt(this.dynamicGridForm.value.type),

      active: this.parameter,
      code_key:this.get_codekey(this.dynamicGridForm.value.name),
      created_by: this.dynamicGridForm.value.created_by,
      masterDgTypes: this.dynamicGridForm.value.masterDgTypes
    }
    if(data.id==null)
    {
      data.id=0;
      data.masterDgTypes='Null';
    }
    // this.service.putpost(data)
    //   .subscribe({
    //     next: (Response: any) => {
    //       console.log("DG Updated");
    //       this.getdata();
    //     }
    //   });


  }


  lastcall() {
    this.dynamicGridForm.reset();
  }

  gotouser() {
    console.log("helo")
    this.route.navigate(['/health']);
  }
}
