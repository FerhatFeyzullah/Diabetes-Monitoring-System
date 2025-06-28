import React from 'react'
import { useParams } from 'react-router-dom'
import DoctorNavbar from '../components/Doctor/DoctorNavbar';

function Doctor() {

  const {userId} = useParams();

  return (


    <div>
      <DoctorNavbar/>
    </div>
  )
}

export default Doctor