import React, { useState } from 'react'
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import { useParams } from 'react-router-dom';

function ArchivePanel() {

    const {doctorId} = useParams();
     const [value,setValue] = useState(0);

    const handleChange = (event, newValue) => {
    setValue(newValue);
  return (
    <div>
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
  )
}}


export default ArchivePanel