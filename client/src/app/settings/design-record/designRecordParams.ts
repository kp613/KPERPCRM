export class DesignRecordParams {
  draw = 1;     //page number
  start = 1;    //Paging first record indicator. This is the start point in the current data set (0 index based - i.e. 0 is the first record).
  length = 5;   //page size

  recordsTotal = 0;
  recordsFiltered = 0;


  orderBy = 'updateDay'
}
