import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Data, TitleStrategy } from '@angular/router';
import { SelectItem } from 'primeng/api';
import { GetdataService } from 'src/app/getdata.service';
import { Answer, Data1, Question } from 'src/app/model/data.model';
import { DataModel } from 'src/app/model/datamodel.model';
import { DialogModule } from 'primeng/dialog';
import { AnsweredQuestion } from 'src/app/model/AnsweredQuestion .model';



@Component({
  selector: 'app-health-profile',
  templateUrl: './health-profile.component.html',
  styleUrls: ['./health-profile.component.css']
})
export class HealthProfileComponent implements OnInit {
[x: string]: any;
  @ViewChild('myButton') myButton: ElementRef | any;
  staticOptions: SelectItem[] = [
    { label: 'Option 1', value: 'option1' },
    { label: 'Option 2', value: 'option2' },
    { label: 'Option 3', value: 'option3' }
];
  maxAnswers: number = 0;
datanew: AnsweredQuestion[] = [];
displayModal: any = false;
data_for_edit:any;
  answer:any[]=[];
  responses: any[] = [];
  addGuidlineForm:any
  click_edit:any=false;
  loading:any=true;
  selectedRole:any;
  formula_for_calulation:any;
  formula: any[]=[];
  datamodel:DataModel[]=[];
  data:any;
  response:any[]=[];
  selectedCities1:number=0;
  newresponse:any;
  reseponsedata:any[]=[];
  healthProfile: any;
  datastatus:boolean=true;
  showdetail:boolean=false;
  activeTab: string = 'general';
  grid:number=0;
  grid_type_id:any;
  final_responses:any[]=[];
  mainclassview:boolean=true;
  filteredresponse:any;
  multiselect_response:any[]=[];
  cities:any=[];
   selectedOptions:any[]=[];

  result_array:any[]=[];
readonly: any=false;
title: any;
  constructor(private service: GetdataService) {
  
   }

  ngOnInit(): void {
    // Code to execute when the component initializes
    // This method is called once the component is initialized
    this.cities=[
      { name: 'New York', id: 1 },
      { name: 'London', id: 2 },
      { name: 'Tokyo', id: 3 },
      { name: 'Paris', id: 4 },
      // Add more cities as needed
    ];
    
    this.getbuttondata();
    this.clickButton();
    // this.answer[107]=1243;
 
  }


 

  onMultiSelectChange(selectedValues: any[], itemId: any) {
    // Convert selected values to a comma-separated string
    this.answer[itemId] = selectedValues.map(value => value.option).join(',');
  }
  onDropdownchange(selectedValue:any, item:any)
  {
    this.answer[item]=selectedValue.option;
  }

  answerBody()
  {
    let val1=0;
    let val2=0;
    let ans=0;
    for(let i=0;i<this.datamodel.length;++i)
    {
      val1=this.answer[this.datamodel[i].calc_field1];
      if(this.datamodel[i].calc_field1_transformation=="Squared")
      {
        val1=val1*val1;
      }
      val2=this.answer[this.datamodel[i].calc_field2];
      if(this.datamodel[i].calc_field2_transformation=="Squared")
      {
        val2=val2*val2;
      }
      
      if(this.datamodel[i].mid_operator=="Plus"){
        ans=val1+val2;
      }
      else if(this.datamodel[i].mid_operator=="Minus")
      {
        ans=val1-val2;
      }
      else if(this.datamodel[i].mid_operator=="Divide")
      {
        ans=val1/val2;
      }
      else{
        ans=val1*val2;
      }
    if(this.datamodel[i].enable_post_operator==true)
    {
      if(this.datamodel[i].post_operator=="Plus"){
        ans=ans+this.datamodel[i].post_operator_val;
      }
      else if(this.datamodel[i].post_operator=="Minus")
      {
        ans=ans-this.datamodel[i].post_operator_val;
      }
      else if(this.datamodel[i].post_operator=="Divide")
      {
        ans=ans/this.datamodel[i].post_operator_val;
      }
      else{
        ans=ans*this.datamodel[i].post_operator_val;
      } 

      this.answer[this.datamodel[i].field_id]=ans;
      console.log(ans);
      ans=0;
      continue;
      

    }
    else{
         console.log(ans);
         ans=0;
         continue;
    }

  }
    
    console.log(this.answer)

  }


  showModal() {
    
    this.answer=[];
    this.displayModal = true;
    
  }

  closeModal() {
    this.displayModal = false;
  }

  onInputChange(event:any)
  {
      console.log("you enterd"+event);
  }
  toggleSelection(questionId: number, optionValue: string) {


    this.multiselect_response.push(optionValue);

    console.log(this.multiselect_response);
   return 123;
  }



  submit()
  {
    if(this.click_edit)
    {

        for(let i=0;i<this.result_array.length;++i)
        {
          const data1 = {
  
        
            responsedto: [
              {
                id: this.result_array[i].answers[this.data_for_edit].transactionid,
                userid: this.result_array[i].answers[this.data_for_edit].userid,
                gridid: this.result_array[i].answers[this.data_for_edit].grid_id,
                questionid:this.result_array[i].answers[this.data_for_edit].questionid,
                question: 'null',
                response:this.answer[this.result_array[i].answers[this.data_for_edit].questionid].toString(),
                time: new Date().toISOString() // Assuming you want current timestamp
              }
            ]
          };


          this.service.post_response(data1)
          .subscribe({
            next:(Response:any)=>
            {
              console.log(Response);
              this.click_edit=false;
              this.getbuttondata();
            }
          });
        }
        this.displayModal=false;
    }
    else{
      this.displayModal=false;
      const multitring=this.multiselect_response.toString();
      console.log(this.answer);
      console.log(this.grid);
  
      for(var i in this.answer){
       let ans= this.answer[i]
        const data = {
  
        
          responsedto: [
            {
              id: 0,
              userid: 1,
              gridid: this.grid,
              questionid: parseInt(i,10),
              question: 'null',
              response:ans.toString(),
              time: new Date().toISOString() // Assuming you want current timestamp
            }
          ]
        };
  
  
        this.service.post_response(data)
        .subscribe({
          next:(Response:any)=>
          {
            console.log(Response);
            this.getbuttondata();
          }
        });
      }
    }
    
      
  }




  onSelectChange(event: any, id: string, item: any) {
    const selectedValue = event.target.value;
    console.log(`Dropdown with id ${id} changed to ${selectedValue}`);
    console.log('Additional item data:', item);
    // Here you can handle the selected value and the additional data as needed
  }
 // use to print the name on button 
  getbuttondata()
  {
    this.service.health_profile()
    .subscribe({
      next:(Response:any)=>
      {
       this.data=Response;
       console.log(this.data)
      }
    });
  }

  clickButton() {
  this.myButton.nativeElement.click();
  }
// giving the questions in based on the grid id
  // getdetails(id:any)
  // {
  //  this.service.getgriddatabyid(id)
  //  .subscribe({
  //   next:(Response:any)=>
  //   {
  //     this.reseponsedata=Response;
  //     this.get_response(id);
  //     console.log(" reseponsedata="+this.reseponsedata);
  //     if(this.reseponsedata.length==0)
  //     {
  //       console.log("No data found")
  //       this.datastatus=false;
  //       this.showdetail=true;
  //     }
  //     else{
  //       this.datastatus=true;
  //       this.showdetail=false;
  //     }
  //   }
  //  });
  // }

  openTab(tabName: string): void {
    this.activeTab = tabName;
    // You can add additional logic here if needed
  }

 
  // give the complete grid detail
  // GetGridData1(id:any)
  //  {
  //   this.grid=id;
  //     this.service.getgrid(0,id)
  //     .subscribe({
  //       next:(Response:any)=>
  //       {
  //         this.response=Response;
       
  //       }
  //     });
  //  }
   // give the complete grid detail
  //  getgriddata(id:any)
  //  {
  //     this.service.getgrid(0,id)
  //     .subscribe({
  //       next:(Response:any)=>
  //       {
  //         this.newresponse=Response;
  //         this.filteredresponse = this.newresponse;
  
          // if(this.newresponse.fields.length==0)
          // {
          //   console.log("No data found")
          //   this.datastatus=false;
          //   this.showdetail=true;
          // }
          // else{
          //   this.datastatus=true;
          //   this.showdetail=false;
          // }
  //         this.get_response(id);
  //       }
  //     });
  //  }   


  // the obove commented method is not in use

  async getFormulas(field_id:any): Promise<void> {
    try {
      const response: any = await this.service.get_formula(field_id).toPromise();
      this.datamodel.push(response[response.length-1]);
       
       
    } catch (error) {
      console.error("Error fetching formula:", error);
    }
     console.log(JSON.stringify(this.datamodel, null, 2) + " formula_for_calulation");
     
  }

  Toget_id(req:any)
  {
     for(let i=0;i<req.length;++i)
     {
      if(req[i].field_type_name==="Calculated")
      {
        this.getFormulas(req[i].id);
      }
     }
  }



   GetGridData(data:any) 
   {

    this.grid=data.id;
   this.grid_type_id=data.type_id;
   this.title=data.name;
    this.service.getgrid(0, this.grid)
      .toPromise()
      .then((response: any) => {
        this.newresponse = response;
        this.filteredresponse = this.newresponse;
          
        this.Toget_id(this.newresponse.fields);
       
        if(this.newresponse.fields.length==0)
        {
          console.log("No data found")
          this.datastatus=false;
          this.showdetail=true;
        }
        else{
          this.datastatus=true;
          this.showdetail=false;
        }
  
        const promises = this.filteredresponse.fields.map((item: any, index: number) => {
          if (item.field_type_name === "Dropdown" ||item.field_type_name === "Multiselect") {
            return this.Options_get_byid(item.id)
              .then((options: any) => {
                if (!this.filteredresponse.fields[index].options) {
                  this.filteredresponse.fields[index].options = [];
                }
                this.filteredresponse.fields[index].options.push(...options);  // Assuming `options` is an array
              })
              .catch((error) => {
                console.error("Error fetching options", error);
              });
              
          } else {
            return Promise.resolve();
          }
          
        });
        
        this.get_response(this.grid);
  
        // After all promises are resolved
        Promise.all(promises).then(() => {
          this.sortFieldsByDetailSortOrder();
          this.sortFieldsBytabularorder();
        });
      })
      .catch((error) => {
        console.error("Error fetching grid data", error);
      });

      console.log(this.filteredresponse.fields)
  }
  sortFieldsByDetailSortOrder() {
    throw new Error('Method not implemented.');
  }
  sortFieldsBytabularorder() {
    throw new Error('Method not implemented.');
  }
  


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
          error: (err: any) => {
            // Reject the promise with the error
            reject(err);
          }
        });
    });
  }

//giving the answer to the question
   get_response(id:any)
   {
    this.service.get_response(id)
    .subscribe({
      next:(Response:any)=>
      {
        this.final_responses=Response;
        this.makeperfect_data();
        console.log("fianal_data "+this.final_responses)
      }
    })
   }


   getItemValue(item: any, heading: any): any {
    return item[heading.name.toLowerCase()];
  }


  makeperfect_data():void
  {
    this.result_array=[];
    for (const question of this.newresponse.fields) {
      const answersForQuestion = [];
      for (const answer of this.final_responses) {
          if (answer.questionid=== question.id) {
              answersForQuestion.push({ ans:answer.response,
                                        time:answer.time,
                                        questionid:answer.questionid,
                                        transactionid:answer.id,
                                        userid:answer.userid,
                                        grid_id:answer.gridid
                                      });
          
          }
      }
      this.result_array.push({
        qusetion: question.name,
          answers: answersForQuestion
      });
    
  }
  console.log(this.result_array);
  // this.result_array = [];
  // for (const question of this.newresponse.fields) {
  //   const answersForQuestion: Answer[] = [];
  //   for (const answer of this.final_responses) {
  //     if (answer.questionid === question.id) {
  //       answersForQuestion.push({ answer: answer, time: answer.time });
  //     }
  //   }
  //   this.result_array.push({
  //     question: question.name,
  //     answers: answersForQuestion
  //   });
  // }

  // console.log(this.result_array);
  }
  // const data: Data1 = {
  //   questions: []
  // };


  // for (const questionData of this.reseponsedata) {
  //   const question: Question = {
  //     questionId: questionData.id,
  //     question: questionData.name,
  //     answers: []
  //   };
  
  //   for (const response of this.final_responses) {
  //     if (response.questionid === questionData.id) {
  //       question.answers.push({
  //         answer: response.response,
  //         time: response.time
  //       });
  //     }
  //   }
  
  //   data.questions.push(question);
  // }

  // console.log(data);
  // this.data=data;
  

 getMaxAnswers(): number[] {
    const maxAnswers = Math.max(...this.result_array.map(item => item.answers.length));
    return Array.from(Array(maxAnswers).keys());
  }
  edit_data(data:any)
  {
    this.click_edit=true;
    console.log(this.result_array);


    // this for loop is use to print the value on the form
    for(let i=0;i<this.result_array.length;++i)
    {
      this.answer[this.result_array[i].answers[data].questionid]=this.result_array[i].answers[data].ans;
      
    }
    console.log(this.answer)
    this.data_for_edit=data;
    this.displayModal = true;

  
    // below code is to post he form 
  //   for(let i=0;i<this.result_array.length;++i)
  //   {


  //     // let ans= this.answer[i]
      

  //     // this.service.post_response(data)
  //     // .subscribe({
  //     //   next:(Response:any)=>
  //     //   {
  //     //     console.log(Response);
  //     //   }
  //     // });
  //     const answer=this.result_array[i].answers[data].ans;
  //     const questionid=this.result_array[i].answers[data].questionid;
  //     const time=this.result_array[i].answers[data].time;
  //     const transactionid=this.result_array[i].answers[data].transactionid;
  //     const userid=this.result_array[i].answers[data].userid;
  //      const gridid=this.result_array[i].answers[data].grid_id;
  //     // console.log("answer : "+this.result_array[i].answers[data].ans,
  //     // "questionid : "+this.result_array[i].answers[data].questionid,
  //     // "time : "+this.result_array[i].answers[data].time,
  //     // "transactionid : "+this.result_array[i].answers[data].transactionid,
  //     // "userid : "+this.result_array[i].answers[data].userid );


  //     const req_data = {
  //       responsedto: [
  //         {
  //           id: transactionid,
  //           userid: userid,
  //           gridid: gridid,
  //           questionid: questionid,
  //           question: 'null',
  //           response:answer,
  //           time: new Date().toISOString() // Assuming you want current timestamp
  //         }
  //       ]
  //     };


  //     this.service.post_response(req_data)
  //     .subscribe({
  //       next:(Response:any)=>
  //       {
  //         console.log(Response);
  //       }
  //     });

  //   }
  console.log(data);
}
  Delete(data:any)
  {
     console.log(data);
     if(confirm("Are you sure want to Delete this Record ?"))
     {
      for(let i=0;i<this.result_array.length;++i)
  {
   const transactionid=this.result_array[i].answers[data].transactionid;
     
   this.service.Delete_response(transactionid)
   .subscribe({
     next:(Response:any)=>
     {
       console.log(Response.message);
     }
   });

  }

     }


  
  }

  // method for multiline


  saveData()
  {

  }
  confirmDialog(data:string)
{
  return 0;
}

  

}

function onInputChange(event: Event | undefined, any: any) {
  throw new Error('Function not implemented.');
}
