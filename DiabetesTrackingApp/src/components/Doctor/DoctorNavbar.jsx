import React, { useState } from 'react'
import '../../css/Doctor.css'
import MailIcon from '@mui/icons-material/Mail';
import PersonIcon from '@mui/icons-material/Person';
import Badge from '@mui/material/Badge';
import { IconButton } from '@mui/material';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';



function DoctorNavbar() {

    const [value,setValue] = useState(0);

    const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <div className='doctor-navbar'>

        <div className='flex-row'>
            <div className='doctor-navbar-title'>
                Diyabet Takip Sistemi
            </div>
            
            <div className='doctor-navbar-tabs'>
                <Tabs value={value} onChange={handleChange}
                 textColor='inherit'
                 indicatorColor="primary">
                <Tab label="Günlük Durum" />
                <Tab label="Reçeteler" />
                <Tab label="Kan Şekeri Ölçümleri" />
                <Tab label="Insulin Değerleri" />
            </Tabs>
            </div>
        </div>
        <div className='flex-row'>
            <div className='doctor-navbar-icons'>                
                    <IconButton >
                        <Badge badgeContent={5} color='warning'>
                         <MailIcon sx={{fontSize:'30px'}}/>
                        </Badge>
                    </IconButton>               
            </div>
            <div className='doctor-navbar-icons'>
                <IconButton>
                    <PersonIcon sx={{fontSize:'30px'}}/>
                </IconButton>
            </div>
        </div>
    </div>
  )
}

export default DoctorNavbar