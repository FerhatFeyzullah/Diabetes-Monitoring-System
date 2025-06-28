import React from 'react'
import LoginNavbar from '../components/Login/LoginNavbar'
import LoginCard from '../components/Login/LoginCard'
import '../css/Login.css'
import Loading from '../components/Loading'
import { useSelector } from 'react-redux'

function Login() {
  const {loading} = useSelector(Store=>Store.auth)
  return (
    <div>

      <LoginNavbar/>

      <div className='login-card'>
        <LoginCard/>
      </div>

      <Loading status={loading}/>
      
    </div>
  )
}

export default Login