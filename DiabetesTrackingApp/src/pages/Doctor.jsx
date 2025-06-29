import React, { useEffect } from 'react'
import { useParams } from 'react-router-dom'
import '../css/Doctor.css'
import DoctorNavbar from '../components/Doctor/DoctorNavbar';
import DoctorDashboard from '../components/Doctor/DoctorDashboard';
import UserList from '../components/Doctor/UserList/UserList';
import { useDispatch } from 'react-redux';
import {GetPatientsForDoctor} from '../redux/slice/doctorSlice'

function Doctor() {

    const {userId} = useParams();
    const dispatch = useDispatch();

    const GetPatient = async(userId)=>{
        const data ={
          doctorId:userId,
        }
    await dispatch(GetPatientsForDoctor(data));
    }
    useEffect(()=>{      
      GetPatient(userId);
    },[])

    return (
        <div>
          <DoctorNavbar/>
          <div className='doctor-screen'>
              <div >
                <UserList/>
              </div>
              <div >
                <DoctorDashboard/>
              </div>
          </div>        
        </div>     
    )
}

export default Doctor