import React, { useEffect } from 'react'
import  {Button} from '@mui/material';
import { useDispatch, useSelector } from 'react-redux';
import { GetBloodSugar, GetDailyStatus, GetInsulin, GetPrescription } from '../../../redux/slice/doctorDashboardSlice';

function UserCard({user}) {

    const {firstName,lastName,id} = user;
    const dispatch = useDispatch();

    const GetDailyData = (patientId) => {
     dispatch(GetDailyStatus(patientId));
     dispatch(GetBloodSugar(patientId));
     dispatch(GetInsulin(patientId));
     dispatch(GetPrescription(patientId));
  };

  return (
    <div className='user-card-main'> 
        <div className='user-card-name'>           
            <Button variant='outlined' size='large' fullWidth
            onClick={() => GetDailyData(id)}
            >{firstName} {lastName}</Button>          
        </div> 
    </div>  
       
  )
}

export default UserCard