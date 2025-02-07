import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { ListItem } from 'ng-multiselect-dropdown/multiselect.model';
import { GetdataService } from '../getdata.service';
import { FormModel } from '../model/FormModel.model';
import { OptionDto } from '../model/OptionDto.model';

@Component({
  selector: 'app-view2',
  templateUrl: './view2.component.html',
  styleUrls: ['./view2.component.css'],
  
})
export class View2Component implements OnInit{
  
  option = [
    { label: 'Option 1', value: 'option1' },
    { label: 'Option 2', value: 'option2' },
    { label: 'Option 3', value: 'option3' },
    { label: 'Option 4', value: 'option4' }
  ];
show_builder:boolean=false;
value:any;
Formula:any[]=[];
displayDeleteModal: any = false;
  field1_transformation:any;
  field2_transformation:any;
  first_value:any;
  second_valu:any;
  operator:any;
  operator2:any;
  showGridDetails:any=true;
  dataList: any[] = [];
  options: string[]=[];
  hori_new_arrya:any[]=[];
  horoDatalist: any[]=[];
  field_response:any[]=[];
  optiondto:OptionDto[]=[];
  form: FormGroup | any;
  horizontal_array:any[]=[];
  vertical_array:any[]=[];
  CalculationForm:FormGroup|any;
  searchQuery:string='';
  draggedItem: any;
  response1: any = {
    fields: [] // your fields array
  };
 count:any[]=[];
 options_on_id:any[]=[];
 showresdata:boolean=true;
 add_new_response:boolean=false;
  searchText = '';
response:any;
filteredresponse:any;
responsefor_horizontal:any;
sortedorder:any;
calculation_preview:string='';
//new things to try
name = "Angular";
cities: any[]= [];

dropdownSettings: IDropdownSettings = {};
//new things end

last_id:any;
responses: any[] = [];
responses123: any = {};
  selectedOptions: any[] = [];
  dropdownVisible = false;
res123:any; 
data:any[]=[];

chkHealthProfile = true;
options_data:any;
showDgFields=true;
dynamicDgFieldData:any = [];
healthProfile:any;
tabluarPreData:any = [];
grid_type_id:any;
id:any;
inputValue: string = '';
idtouse:number=0;
isChecked: boolean = true;
Responseform: FormGroup|any;
currenttime:Date|any;
showsuspect:any=false;
showresponse:any=false;
response_count_check:boolean=true;
showcpt:any=false;
option_list:any;
detailPreData:any = [];
Selecteddata:number=1;
formData: any = 
{
  subscribe: false
}; 
newResponses: any[] = [];
multiselect_response:any[]=[];

suspect:any={
  Title:'Text Input Suspects',
If_value_entered_is : 'Equal',
Qualifier_value:10,
Add_this_condition_as_suspect:'C44.301 - UNSP MALIG NEOP SKN OF NOSE'
}

  cpt_gen:any={
  title:'CPT Generation', 
  if_value_entered_is: 'Equal',
  Qualifier_value:10,
  Genrate_prodecural_code:'0488T - DIABETES PREV ONLINE/ELEC'
  }
  settings={};

  Is_integer_only:any[]=[];
  selectedItems: { item_id: number; item_text: string; }[] | undefined;
  //dropdownSettings: { singleSelection: boolean; defaultOpen: boolean; autoPosition: boolean; idField: string; textField: string; selectAllText: string; unSelectAllText: string; enableCheckAll: boolean; allowSearchFilter: boolean; };

  constructor(private service:GetdataService,private fb: FormBuilder,private route: ActivatedRoute, private route1: Router)
  {
      this.draggedItem=null;
 
  }
  ngOnInit(): void {


    this.get_option();

    this.cities = [
      { item_id: 1, item_text: "New Delhi" },
      { item_id: 2, item_text: "Mumbai" },
      { item_id: 3, item_text: "Bangalore"},
      { item_id: 4, item_text: "Pune" },
      { item_id: 5, item_text: "Chennai" },
      { item_id: 6, item_text: "Navsari" }
    ];
    this.selectedItems = [
      { item_id: 4, item_text: "Pune" },
      { item_id: 6, item_text: "Navsari" }
    ];
    this.dropdownSettings = {
      singleSelection: false,
      defaultOpen: false,
      idField: "item_id",
      textField: "item_text",
      selectAllText: "Select All",
      unSelectAllText: "UnSelect All",
      itemsShowLimit: 3
    };

    this.data = [
      { item_id: 1, item_text: 'Hanoi' },
      { item_id: 2, item_text: 'Lang Son' },
      { item_id: 3, item_text: 'Vung Tau' },
      { item_id: 4, item_text: 'Hue' },
      { item_id: 5, item_text: 'Cu Chi' },
    ];
    this.id = this.route.snapshot.queryParams['id'];
    this.grid_type_id=this.route.snapshot.queryParams['grid_type_id'];
 
    this.form = this.fb.group({
      id: [0, Validators.required],
      name: ['', Validators.required],
      field_type_id:  [null, Validators.required],
  field_type_name:[''],
  has_response_values:[2],
  is_required: [null, Validators.required],
  is_integer_only: [true],
  integer_validation_min:[null],
  integer_validation_max:[null],
  lookup_dataset:[0],
  lookup_dataset_name: [''],
  datagrid_id: [this.id],
  status:  [null, Validators.required],
  show_in_tabular: [null, Validators.required],
  tabular_sort_order: [1],
  show_in_detail: [null, Validators.required],
  detail_sort_order: [1],
  response_count: [3],
  field_tooltip: [''],
  field_selected_value: [2],
  edited_field_result_id: [1],
      dgFieldCalculation: this.fb.group({
        id: [0],
        calc_field1: [0],
        calc_field1_transformation: ['string'],
        calc_field2: [0],
        mid_operator: [''],
        calc_field2_transformation: ['string'],
        enable_post_operator: [true],
        post_operator: ['string'],
        post_operator_val: [0],
        field_id: [0]
      })
    });




    this.CalculationForm = this.fb.group({
      id:[0],
      calc_field1: ['', Validators.required],
      calc_field1_transformation: [{value: '', disabled: true}, Validators.required],
      mid_operator: [{value: '', disabled: true}, Validators.required],
      calc_field2: [{value: '', disabled: true}, Validators.required],
      calc_field2_transformation: [{value: '', disabled: true}, Validators.required],
      enable_post_operator: [false],
      post_operator: [{value: ''}],
      post_operator_val: [{value: ''}]
    });

    this.currenttime=new Date();
    this.Responseform = this.fb.group({
      dgFieldResponses: this.fb.array([
        this.fb.group({
          id: [0],
          name: ['', Validators.required],
          field_id: [0 , Validators.required],
          active: [, Validators.required],
          ideal_choice: [true, Validators.required],
          response_sort_order: [ 0, Validators.required],
          created_datetime: [this.currenttime, Validators.required],
          created_by: [1, Validators.required],
          modified_datetime: [this.currenttime, Validators.required],
          modified_by: [1, Validators.required]
        })
      ])
    });


    

    this.getdata();

     this.fun();
  //  this.GetGridData();
   
  //  this.getdata();

  //  //this.GetGridData2();
  //  this.countresponse();

   this.settings = {
    singleSelection: false,
    idField: 'item_id',
    textField: 'item_text',
    enableCheckAll: true,
    selectAllText: 'Chọn All',
    unSelectAllText: 'Hủy chọn',
    allowSearchFilter: true,
    limitSelection: -1,
    clearSearchFilter: true,
    maxHeight: 197,
    itemsShowLimit: 3,
    searchPlaceholderText: 'Tìm kiếm',
    noDataAvailablePlaceholderText: 'Không có dữ liệu',
    closeDropDownOnSelection: false,
    showSelectedItemsAtTop: false,
    defaultOpen: false,
  };
  }

  async fun(): Promise<void> {
    await this.GetGridData();
    await this.getdata();
    await this.countresponse();
  }
  // onItemSelect(item: any) {
  //   console.log('onItemSelect', item);
  // }
  // onItemDeSelect(item: any) {
  //   console.log('onItem DeSelect', item);
  // }

  // onSelectAll(items: any) {
  //   console.log('onSelectAll', items);
  // }

  // onDropDownClose() {
  //   console.log('dropdown closed');
  // }


showsuspectmodel()
{
  this.showsuspect=true;
}
showresponsemodel(count:any)
{
  this.showresponse=true;
  this.add_new_response=false;
  if(count===0)
  {
    this.response_count_check=false;
  }
  else{
    this.response_count_check=true;
  }
}
showcptmodel()
{
  this.showcpt=true;
}
  openDeleteDialog() {
    this.displayDeleteModal = true;
  }
  onSelectChange(questionId: string, selectedOptions: HTMLOptionsCollection) {
    const selectedValues = Array.from(selectedOptions)
      .filter(option => option.selected)
      .map(option => option.value);

    this.responses[0] = selectedValues;
  }


  toggleControls(controlName: string) {
    const enableNextControl = this.CalculationForm.get(controlName);
    if (enableNextControl) {
      enableNextControl.enable();
    }
      this.calculation_preview=this.CalculationForm.value.calc_field1+this.CalculationForm.value.mid_operator+this.CalculationForm.value.calc_field2;
  }

  get_name(id:any)
  {
  
  }
  
  toggleDropdown() {
    this.dropdownVisible = !this.dropdownVisible;
  }

  toggleOption(option: any) {
    const index = this.selectedOptions.findIndex(item => item.value === option.value);
    if (index === -1) {
      this.selectedOptions.push(option);
    } else {
      this.selectedOptions.splice(index, 1);
    }
  }

  isSelected(option: any): boolean {
    return this.selectedOptions.some(item => item.value === option.value);
  }

  preventClose(event: MouseEvent) {
    event.stopPropagation();
  }


  onCheckboxChange(event: any) {
    if (event.target.checked) {
      console.log("You checked");
    }
  }
  toggleSelection(questionId: number, optionValue: string) {


    this.multiselect_response.push(optionValue);

    console.log(this.multiselect_response);
    // const index = this.multiselect_response[questionId].indexOf(optionValue);
    // if (index === -1) {
    //   this.responses1[questionId].push(optionValue);
    // } else {
    //   this.responses1[questionId].splice(index, 1);
    // }
  }

  get_option()
  {
     this.service.get_options()
     .subscribe({
      next:(Response:any)=>
      {
        this.options_data=Response;
        this.option_list=this.options_data.dgFieldTypes;
      }
     })
  }


//options get by id

Options_get_byid(id: any): Promise<any> {
  // Return a new Promise
  return new Promise((resolve, reject) => {
    // Call the service method
    this.service.get_option_by_id(id)
      .subscribe({
        next: (response: any) => {
          // Resolve the promise with the response data
          resolve(response);
        },
        error: (err:any) => {
          // Reject the promise with the error
          reject(err);
        }
      });
  });
}


//code for option
  updateOption(index: number, value: string) {
    this.options[index] = value; // Update the value in options array
  }
  addOption() {
    this.options.push(''); // Add an empty string to options array
  }  
  onSelectionChange(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue === '3'|| selectedValue==='4') {
      // Clear the options array when dropdown is selected
      this.options = [];
    }
  }
  Submit_option()
  {
      alert(this.options);
  }
  
async countresponse()
{
  this.service.getcount()
  .subscribe({
    next:(Response:any)=>
    {
      this.count=Response;
     console.log(Response)
     console.log(this.count[0])
    }
  });
}

  Get_Respnse_Count(fieldid:any)
  {
    const filteredResponses = this.count.filter((res: { field_id: any; }) => res.field_id === fieldid);
    const count = filteredResponses.length;
    return count;
  }

  search()
  {
    console.log(this.res123);
    this.filteredresponse.fields = this.filteredresponse.fields.filter((item: { name: string; }) =>
      item.name.toLowerCase().includes(this.searchQuery.toLowerCase())
    );

    console.log(this.filteredresponse);
    console.log(this.res123);
  }

  save() {
    // Logic for saving the main suspect details
    console.log("Saved main suspect details:", this.suspect);
  }
  
  

  addNewResponse() {
    // Logic for adding a new response
    this.newResponses.push({
      If_value_entered_is: 'Equal',
      Qualifier_value: null,
      Add_this_condition_as_suspect: ''
    });
  }

  add_new_response_enable()
  {
    this.add_new_response=true;
  }
  submitresponse() {
    this.showresponse=false;
    this.Responseform.value.dgFieldResponses[0].name=this.formData.name;
    this.Responseform.value.dgFieldResponses[0].ideal_choice=this.formData.subscribe;
    if(this.formData.status=="true")
    {
      this.Responseform.value.dgFieldResponses[0].active=true;
    }
    else{
      this.Responseform.value.dgFieldResponses[0].active=false;
    }
   
    this.Responseform.value.dgFieldResponses[0].field_id=this.idtouse;
    console.log(this.Responseform.value);
      this.service.postresponse(this.Responseform.value)
      .subscribe({
        next:(Response:any)=>
        {
           
        }
      });

    
    
  }



  onSubmit()
  {
    console.log(this.form.value);
    if (this.form.valid) {
      const formData: FormModel = this.form.value;
      // if(this.data[0].name==="Tabular")
      // {
      //   formData.field_type_id=1;
      // }
      // else{
      //   formData.field_type_id=2;
      // }

      if(this.form.value.status=="true" || this.form.value.status==true)
      {
        formData.status=true;
      }
      else{
        formData.status=false;
      }
      //formData.status=Boolean(formData.status);
      formData.field_type_id=Number(formData.field_type_id);
      if(formData.field_type_id==1)
      {
        formData.field_type_name="Text";
      }
      else if(formData.field_type_id==2)
      {
        formData.field_type_name="Textarea";
      }
      
      else if(formData.field_type_id==3)
      {
        formData.field_type_name="Dropdown";
      }
      else if(formData.field_type_id==5)
      {
        formData.field_type_name="Calculated";
      }
      else{
        formData.field_type_name="Multiselect";
      }
      console.log(formData);
    this.service.postfield(formData)
    .subscribe({
      next:(Response:any)=>
      {
        this.last_id=Response.data;
        if(formData.field_type_id==4 ||formData.field_type_id==3)
        {
          this.post_options();
        }
        else if(formData.field_type_id==5)
        {
          this.post_calculation();
        }
           
        console.log('form submited');
        this.form.reset();
        window.location.reload();
      }
    });
  }
    console.log(this.form)
  }


  calculationSubmit()
  {
    console.log(this.CalculationForm.value)

    this.post_calculation();
  }


  Builder_preview()
  {
     this.show_builder=true;
    for(let i=0;i<this.Is_integer_only.length;++i)
    {
      if(this.Is_integer_only[i].id===parseInt(this.CalculationForm.value.calc_field1,10))
      {
        this.first_value=this.Is_integer_only[i].name;
      }
      if(this.Is_integer_only[i].id===parseInt(this.CalculationForm.value.calc_field2,10))
      {
        this.second_valu=this.Is_integer_only[i].name;
      }
      
    }
    if(this.CalculationForm.value.mid_operator==='Plus')
    {
       this.operator='+';
    }
    else if(this.CalculationForm.value.mid_operator==='Minus')
    {
      this.operator='-';
        
    }
    else if(this.CalculationForm.value.mid_operator==='Divide')
    {
      this.operator='/';
       
    }
    else{
       this.operator='X';
        
    }
    
   // this.operator2=this.CalculationForm.value.post_operator;
    if(this.CalculationForm.value.calc_field1_transformation=='Squared')
    {
      this.field1_transformation=2;
    }
    else{
      this.field1_transformation='';
    }
    if(this.CalculationForm.value.calc_field2_transformation=='Squared')
    {
      this.field2_transformation=2;

    }
    else{
      this.field2_transformation='';

    }

    this.calculation_preview = `${this.field1_transformation}^${this.first_value} ${this.operator} ${this.field2_transformation}^${this.second_valu}`;

  }


  post_operator()
  {
    if(this.CalculationForm.value.post_operator==='Plus')
    {
       this.operator2='+';
    }
    else if(this.CalculationForm.value.post_operator==='Minus')
    {
      this.operator2='-';
        
    }
    else if(this.CalculationForm.value.post_operator==='Divide')
    {
      this.operator2='/';
       
    }
    else{
       this.operator2='X';
        
    }
    
  }

  post_calculation()
  {
    console.log(this.CalculationForm.value);
    console.log(this.CalculationForm.value);
     this.CalculationForm.value.field_id= parseInt(this.last_id,10);
     this.CalculationForm.value.calc_field1=parseInt(  this.CalculationForm.value.calc_field1,10);
     this.CalculationForm.value.calc_field2=parseInt(  this.CalculationForm.value.calc_field2,10);
   
    if(this.CalculationForm.value.post_operator.value==='')
    {
      this.CalculationForm.value.post_operator="Na"
    }
    if(this.CalculationForm.value.post_operator_val.value==='')
    {
      this.CalculationForm.value.post_operator_val=0;
    }
    console.log(this.CalculationForm.value);
   this.service.post_calculation(this.CalculationForm.value)
   .subscribe({
    next:(Response:any)=>
    {
      console.log(Response)
    }
   });
  }

  assign_new_value()
  {
    this.value=this.CalculationForm.value.post_operator_val;
  }

  post_options()
  {
    console.log(this.options);
      const num=parseInt(this.last_id,10);
      for(let i=0;i<this.options.length;++i)
      {
      const Dto={
        optiondto:[
          {
        id: 0,
        dgFieldId: num,
        option: this.options[i]
        }
      ]
      }
      this.service.post_option(Dto)
      .subscribe({
        next :(Response:any)=>
        {
          console.log("Option Added");
        }
      });

    }
        
      
  }

  async GetGridData() {
    this.service.getgrid(0, this.id)
      .toPromise()
      .then((response: any) => {
        this.response = response;
        this.res123 = JSON.parse(JSON.stringify(response));
        this.filteredresponse = this.response;
        this.responsefor_horizontal=this.filteredresponse;
        this.get_horizontal_data();
        this.Options_for_calculation();  
        const promises = this.filteredresponse.fields.map((item: any, index: number) => {
          if (item.field_type_name === "Dropdown"||item.field_type_name === "Multiselect" ) {
            return this.Options_get_byid(item.id)
              .then((options: any) => {
                if (!this.filteredresponse.fields[index].options) {
                  this.filteredresponse.fields[index].options = [];
                }
                this.filteredresponse.fields[index].options.push(...options);
                console.log(this.filteredresponse.fields);  // Assuming `options` is an array
              })
              
              .catch((error) => {
                console.error("Error fetching options", error);
              });

              
          } else {
            console.log("Promise reosl")
            return Promise.resolve();
          }
        });
  
        // After all promises are resolved
        Promise.all(promises).then(() => {
          this.sortFieldsByDetailSortOrder();
          this.sortFieldsBytabularorder();
        });
      })
      .catch((error) => {
        console.error("Error fetching grid data", error);
      });

      console.log(this.filteredresponse.fields);
  }




  Options_for_calculation() {
    this.filteredresponse.fields.forEach((item: any) => {
      if (item.is_integer_only === true) {
        this.Is_integer_only.push({ id: item.id, name: item.name });
        
      }
    });
    console.log(this.Is_integer_only);
  }

  
  
 
  
  

  //  GetGridData2()
  //  {
  //     this.service.getgrid(0,this.id)
  //     .subscribe({
  //       next:(Response:any)=>
  //       {
  //         this.res123=Response;
  //         this.filteredresponse=Response;
  //       }
  //     });
      
  //  }

   DeletePermanantly()
   {

    if(this.inputValue=="permanently delete")
    {
      console.log(this.inputValue);
      this.service.delete_dg_fields(this.idtouse)
    .subscribe({
      next:(Response:any)=>
      {
        alert(Response.message);
        window.location.reload();
      }
    });
    
    }
    else{
      alert("Unable to delte this field");
    }
    
   }
   async getdata()
   {
    console.log("Hello");
     this.service.getdatabyid(this.id)
     .subscribe({
       next:(Response:any)=>
       {
         this.data=Response;
       }
     })
   }


   filterFields(): any[] {
    let filedData = this.filterBasedOnDetail();    
    return filedData.filter((i: { name: string; }) => i.name.toLowerCase().indexOf(this.searchText.toLowerCase()) > -1);
  }
  keyPressNumbers(event:any)
  {
         
  }

  filterTabularShowCount()
  {
    return this.dynamicDgFieldData != null && this.dynamicDgFieldData.length > 0 ? 
    this.dynamicDgFieldData.filter((x: { show_in_tabular: any; status: any; })=>x.show_in_tabular && x.status).sort((x: { tabular_sort_order: any; })=>x.tabular_sort_order).length > 0 : false;
  }
  fillDetailPreData()
  {}
  dropdaragField(event:any)
  {
    const data=this.responsefor_horizontal.fields;
    moveItemInArray(data, event.previousIndex, event.currentIndex);

     data
        .forEach((x: { tabular_sort_order: any; }, idx: number) => {          
            x.tabular_sort_order = idx + 1;
        });
    for(let i=0;i<data.length;++i)
    {
      this.horizontal_array[i]=data[i].id;
    }
    console.log(this.horizontal_array);
    this.updatehoriontal(this.horizontal_array);
   console.log(this.hori_new_arrya);
  
  }

  get_horizontal_data()
  {
    let sr=1;
      for(let i=0;i<this.responsefor_horizontal.fields.length;++i)
      {
          for(let j=0;j<this.responsefor_horizontal.fields.length;++j)
          {
            if(this.responsefor_horizontal.fields[j].tabular_sort_order===sr)
            {
              this.hori_new_arrya[i]=this.responsefor_horizontal.fields[j];
              sr++;
              break;
            }
          }
      }

      console.log(this.hori_new_arrya);
  }

  dropdaragVertical(event:any)
  {
    const data=this.filteredresponse.fields;
    moveItemInArray(data, event.previousIndex, event.currentIndex);

     data
      .forEach((x: { detail_sort_order: any; }, idx: number) => {        
          x.detail_sort_order = idx + 1;
      });
      console.log(data);
    for(let i=0;i<data.length;++i)
    {
      this.vertical_array[i]=data[i].id;
    }
    this.updateorder(this.vertical_array);
  }
  // updateSortOrder(data: any){
  //   let fieldList = {
  //     dgFields:data!= undefined && data != null ? data : []
  //   };

  //   this.clinicalAssetService.UpdateFieldOrderData(fieldList).subscribe(
  //     (result: any) => {                
  //       if(result.status == 200){
  //         this.getDataGridDetails();
  //       }
  //     },
  //     (error) => { }
  //   );
  // }
  back()
  {
     this.route1.navigate(['/'])
  }
  create()
  {
    this.form = this.fb.group({
      id: [0, Validators.required],
      name: ['', Validators.required],
      field_type_id:  [null, Validators.required],
  field_type_name:[''],
  has_response_values:[2],
  is_required: [null, Validators.required],
  is_integer_only: [true],
  integer_validation_min:[null],
  integer_validation_max:[null],
  lookup_dataset:[0],
  lookup_dataset_name: [''],
  datagrid_id: [this.id],
  status:  [null, Validators.required],
  show_in_tabular: [null, Validators.required],
  tabular_sort_order: [1],
  show_in_detail: [null, Validators.required],
  detail_sort_order: [1],
  response_count: [3],
  field_tooltip: [''],
  field_selected_value: [2],
  edited_field_result_id: [1],
      dgFieldCalculation: this.fb.group({
        id: [0],
        calc_field1: [0],
        calc_field1_transformation: ['string'],
        calc_field2: [0],
        mid_operator: [''],
        calc_field2_transformation: ['string'],
        enable_post_operator: [true],
        post_operator: ['string'],
        post_operator_val: [0],
        field_id: [0]
      })
    });
  }

  filterTabularData(){
    let showTabluarRecord = this.response.length > 0 ? this.dynamicDgFieldData.filter((x: { show_in_tabular: any; status: any; })=>x.show_in_tabular && x.status): [];
    let nonShowTabluarRecord = this.dynamicDgFieldData.length > 0 ? this.dynamicDgFieldData.filter((x: { show_in_tabular: any; status: any; })=>!x.show_in_tabular && x.status) : [];
    if(showTabluarRecord != null && showTabluarRecord.length > 0){
      this.tabluarPreData = showTabluarRecord;
      if(nonShowTabluarRecord != null && nonShowTabluarRecord.length > 0)
          nonShowTabluarRecord.forEach((i: any)=>{
            this.tabluarPreData.push(i);
          });          
    }else{
      this.tabluarPreData = [];
    }
    return this.tabluarPreData;
  }
 
  newFieldModel(str:any){
    console.log(str);
    this.form.controls['id'].setValue(str.id);
    this.form.controls['name'].setValue(str.name);
    this.form.controls['field_tooltip'].setValue(str.field_tooltip);
    this.form.controls['field_type_id'].setValue(str.field_type_id);
    this.form.controls['status'].setValue(str.status);
    this.form.controls['is_required'].setValue(str.is_required);
    this.form.controls['show_in_tabular'].setValue(str.show_in_tabular);
    this.form.controls['show_in_detail'].setValue(str.show_in_detail);
    if(str.field_type_id===5)
    {
      this.form.value.field_type_id='5';  
      this.service.get_formula(str.id)
      .subscribe({
        next:(Response:any)=>
        {
            this.Formula=Response;
            this.CalculationForm.controls['id'].setValue(this.Formula[0].id);
            this.CalculationForm.controls['calc_field1'].setValue(this.Formula[0].calc_field1);   
            this.CalculationForm.controls['calc_field2'].setValue(this.Formula[0].calc_field2);
            this.CalculationForm.controls['calc_field1_transformation'].setValue(this.Formula[0].calc_field1_transformation);
            this.CalculationForm.controls['calc_field2_transformation'].setValue(this.Formula[0].calc_field2_transformation);
            this.CalculationForm.controls['mid_operator'].setValue(this.Formula[0].mid_operator);
            this.CalculationForm.controls['enable_post_operator'].setValue(this.Formula[0].enable_post_operator);
            this.CalculationForm.controls['post_operator'].setValue(this.Formula[0].post_operator);
            this.CalculationForm.controls['post_operator_val'].setValue(this.Formula[0].post_operator_val);
            this.toggleControls('calc_field2');
            this.toggleControls('calc_field2');
            this.toggleControls('calc_field1_transformation');
            this.toggleControls('calc_field2_transformation');
            this.toggleControls('mid_operator');
            this.toggleControls('enable_post_operator');
            this.toggleControls('post_operator_val');

        }
      });
   
    }
  }

  deleteField(item:any)
  {
    this.idtouse=item.id
        // this.service.delete_dg_fields(item.id)
    // .subscribe({
    //   next:(Response:any)=>
    //   {
    //     console.log(Response.message);
    //   }
    // })
  }
  enableSuspect(item:any){}
  suspectModal(item:any){}
  responseModal(item:any)
  {
    this.idtouse=item.id;
     this.getdataresponse(this.idtouse);
     const count =this.Get_Respnse_Count(this.idtouse);
     if(count==0)
     {
      this.showresdata=false;
     }
     else{
      this.showresdata=true;
     }
     console.log(this.field_response);
  }
  cptGenModal(item:any){}


  getdataresponse(id:any)
  {
    this.service.getdataresponse(id)
    .subscribe({
      next:(Response:any)=>
      {
        this.field_response=Response;
        console.log("this is new test: "+this.field_response.length);
      }
    });
  }

  filterBasedOnDetail(){
    let result = [];
    result=this.response;
    // let showTabluarRecord = this.dynamicDgFieldData.length > 0 ? this.dynamicDgFieldData.filter(x=>x.show_in_detail && x.status): [];
    // showTabluarRecord = showTabluarRecord.sort(function(a, b) {
    //   if (a.detail_sort_order < b.detail_sort_order)
    //     return -1;
    //   if (a.detail_sort_order > b.detail_sort_order)
    //     return 1;
    //   return 0;
    // });
    // let nonShowTabluarRecord = this.dynamicDgFieldData.length > 0 ? this.dynamicDgFieldData.filter(x=>!x.show_in_detail&& x.status) : [];
    // if(showTabluarRecord != null && showTabluarRecord.length > 0){
    //   result = showTabluarRecord;
    // }
    // let disabledFields = this.dynamicDgFieldData.length > 0 ? this.dynamicDgFieldData.filter(x=>!x.status) : [];
    // if(nonShowTabluarRecord != null && nonShowTabluarRecord.length > 0){
    //   nonShowTabluarRecord.forEach(i=>{
    //     result.push(i);
    //   });          
    // }
    // son/ daughter of Mr./Mrs age participated  in the summer camp season 2 organize by Legends Sports Club
    // in collaboration with Unity Cricket Academy he/ she awarded this certificate for his/her distinactive performance in this camp
    // if(disabledFields != null && disabledFields.length > 0){
    //   disabledFields.forEach(i=>{
    //     result.push(i);
    //   });
    // }  
    return result;
  }
  fillTabularPreData(){
    // this.tabluarPreData = this.filterTabularData();
    // this.tabluarPreData =  this.tabluarPreData.length > 0 ? this.tabluarPreData.filter((x: { show_in_tabular: any; status: any; })=>x.show_in_tabular && x.status).sort(function(a, b) {
    //   if (a.tabular_sort_order < b.tabular_sort_order)
    //     return -1;
    //   if (a.tabular_sort_order > b.tabular_sort_order)
    //     return 1;
    //   return 0;
    // }) : this.tabluarPreData;
    // return this.tabluarPreData;
  }



  onDragStart(event: DragEvent, item: any) {
    this.draggedItem = item; // Store the dragged item
    event.dataTransfer?.setData('text/plain', 'dragged'); // Set data to indicate dragging
  }

  onDragOver(event: DragEvent) {
    event.preventDefault();
  }

  onDrop(event: DragEvent) {
    event.preventDefault();
    if (this.draggedItem) {
      // Create a copy of the fields array
      const modifiedFields = [...this.res123.fields];
      
      // Get the index of the dragged item
      const draggedIndex: number = modifiedFields.indexOf(this.draggedItem);
      
      // Remove the dragged item from the modified array
      modifiedFields.splice(draggedIndex, 1);
      
      // Generate a random index to drop the item at
      const randomIndex: number = Math.floor(Math.random() * (modifiedFields.length + 1));
      
      // Insert the dragged item at the random index
      modifiedFields.splice(randomIndex, 0, this.draggedItem);
      
      // Update the response object with the modified fields array
      this.res123 = { ...this.res123, fields: modifiedFields };
      
      this.horoDatalist = [];
      for(let i=0;i<this.res123.fields.length;++i)
      {
        this.horoDatalist.push(this.res123.fields[i].id);
      
      }
      console.log(this.horoDatalist);
              // Reset the dragged item
              //call update method here
              this.updatehoriontal(this.horoDatalist);
            this.draggedItem = null;
          }
      this.draggedItem = null;
    }
  


  onDrop1(event: DragEvent) {
    event.preventDefault();
    if (this.draggedItem) {
      // Create a copy of the fields array
      const modifiedFields = [...this.filteredresponse.fields];
      
      // Get the index of the dragged item
      const draggedIndex: number = modifiedFields.indexOf(this.draggedItem);
      
      // Remove the dragged item from the modified array
      modifiedFields.splice(draggedIndex, 1);
      
      // Generate a random index to drop the item at
      const randomIndex: number = Math.floor(Math.random() * (modifiedFields.length + 1));
      
      // Insert the dragged item at the random index
      modifiedFields.splice(randomIndex, 0, this.draggedItem);
      
      // Update the response object with the modified fields array
      this.filteredresponse = { ...this.filteredresponse, fields: modifiedFields };
      

      //adding data
      this.dataList = [];
for(let i=0;i<this.filteredresponse.fields.length;++i)
{
  this.dataList.push(this.filteredresponse.fields[i].id);

}
console.log(this.dataList);
        // Reset the dragged item
        //call update method here
        this.updateorder(this.dataList);
      this.draggedItem = null;
    }
  }



  updateorder(order:any[])
  {
    this.service.updatesort_order(order)
    .subscribe({
      next:(Response:any)=>
      {
         console.log("order Updated")
      }
    });
    this.GetGridData();
  }
  updatehoriontal(order:any[])
  {
    debugger
    this.service.updatesort_horizontal_order(order)
    .subscribe({
      next:(Response:any)=>
      {
      
         console.log("order Updated")
      }
    });
    this.GetGridData();
  }


  sortFieldsByDetailSortOrder(): void {
    this.filteredresponse.fields = [...this.filteredresponse.fields].sort((a, b) => a.detail_sort_order - b.detail_sort_order);
    console.log(this.filteredresponse.fields);

    
  } 

  sortFieldsBytabularorder(): void {
    this.res123.fields = [...this.res123.fields].sort((a, b) => a.tabular_sort_order - b.tabular_sort_order);
    console.log(this.res123.fields);

    
  }
  
}
