import axios from "../ts_typings/axios";    //it appears that axios.d.ts has an "export" instruction inside,
import { greet } from "./mylib";
//which means it's treater as a module => it's contents should be imported
//=> this file also becomes a module

//soo looks like all the files in the project become modules, all would have these "import"/"export" instructions

greet();
axios.get('/user?ID=123456')

$("#www").add("");