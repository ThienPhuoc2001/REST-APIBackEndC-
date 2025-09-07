
import {useEffect} from "react";

const API = "http://localhost:5000/person";


export function  ListOfPerson(){
    useEffect(()=>{
        fetch(API)
            .then(response => response.json())
        .then(data => {
            console.log(data);
        })
        .catch(error => {
            console.error('Error fetching lists of person', error)
        });
    }, []);
return null; 
    }
    
    export default ListOfPerson;
    
    