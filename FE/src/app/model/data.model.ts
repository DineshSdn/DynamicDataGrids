export interface Data1 {
    questions: Question[];
  }
  
  export interface Question {
    questionId: number;
    question: string;
    answers: Answer[];
  }
  
  export interface Answer {
    answer: string;
    time: string;
  }
  