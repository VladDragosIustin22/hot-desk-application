import dayjs, { Dayjs } from 'dayjs';
import { DemoItem } from '@mui/x-date-pickers/internals/demo';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { TimePicker } from '@mui/x-date-pickers/TimePicker';
import { grey, orange } from '@mui/material/colors';
import {
  Box,
  Button,
  Typography,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  AppBar,
  Toolbar,
} from '@mui/material';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import React from 'react';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { TimeView } from '@mui/x-date-pickers';
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Switch from '@mui/material/Switch';



const theme = createTheme({
  palette: {
    primary: {
      main: grey[900],
    },
    secondary: {
      main: orange[500],
    
    },
  },
  typography: {
    fontSize: 20,
    
    
  },
});

function  DatePickerValue() {
  const [value, setValue] = React.useState<Dayjs | null>(dayjs());
   const [allDay, setAllDay] = React.useState<boolean>(false);
  return (
    <FormControl sx={{ width: '64ch', mb:4 }}>
    <LocalizationProvider dateAdapter={AdapterDayjs}>
    <Box sx={{ display: 'flex', alignItems: 'center' }}>
      <DatePicker
        label="Date"
        value={value}
        onChange={(newValue) => setValue(newValue)}
        sx={{ width: '64ch' }}
      />
      
      <FormGroup sx={{ mr:-20,ml: 'auto' }}>
      <FormControlLabel control={<Switch checked={allDay} onChange={(event) => setAllDay(event.target.checked)} />} label="All day" color='secondary.main'/>
    </FormGroup>
    </Box>
    </LocalizationProvider>
    </FormControl>
  );
}
 

function BasicSelect() {
  const [headquarters, setHeadquarters] = React.useState('');
  const [floor, setFloor] = React.useState('');
  const [desk, setDesk] = React.useState('');

  const handleHeadquartersChange = (event: { target: { value: React.SetStateAction<string>; }; }) => {
    setHeadquarters(event.target.value);
  };

  const handleFloorChange = (event: { target: { value: React.SetStateAction<string>; }; }) => {
    setFloor(event.target.value);
  };

  const handleDeskChange = (event: { target: { value: React.SetStateAction<string>; }; }) => {
    setDesk(event.target.value);
  };

  return (
    <Box
      sx={{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'left',
        mt: 2, 
      }}
    >
      <FormControl sx={{ width: '64ch', mb: 5 }}>
        <InputLabel id="select-office">Office</InputLabel>
        <Select
          labelId="select-office"
          id="select-office"
          value={headquarters}
          label="Office"
          onChange={handleHeadquartersChange}
        >
          <MenuItem value={10}>Predeal</MenuItem>
          <MenuItem value={20}>Brizei</MenuItem>
        </Select>
      </FormControl>

      <FormControl sx={{ width: '25ch', mb: 5 ,alignItems:'left'}}>
        <InputLabel id="select-floor">Floor</InputLabel>
        <Select
          labelId="select-floor"
          id="select-floor"
          value={floor}
          label="Floor"
          onChange={handleFloorChange}
        >
          <MenuItem value={11}>0</MenuItem>
          <MenuItem value={12}>1</MenuItem>
          <MenuItem value={13}>2</MenuItem>
          
        </Select>
      </FormControl>

      <FormControl sx={{ width: '25ch', mb: 5,alignItems:'left' }}>
        <InputLabel id="select-desk">Desk</InputLabel>
        <Select
          labelId="select-desk"
          id="select-desk"
          value={desk}
          label="Desk"
          onChange={handleDeskChange}
        >
          <MenuItem value={16}>1</MenuItem>
          <MenuItem value={17}>2</MenuItem>
          <MenuItem value={18}>3</MenuItem>
          <MenuItem value={19}>4</MenuItem>
          <MenuItem value={20}>5</MenuItem>
        </Select>
      </FormControl>
    </Box>
  );
}
  
 

function ReserveDesk() {
  const [startTime, setStartTime] = React.useState<Dayjs | null>(
    dayjs().set('hour', 7).set('minute', 0)
  );
  const [endDateTime, setEndTime] = React.useState<Dayjs | null>(null);
  const [allDay, setAllDay] = React.useState<boolean>(false);
  
  const handleStartTimeChange = (newValue: Dayjs | null) => {
  setStartTime(newValue);
    if (allDay) {
      setEndTime(null);
    }
  };

  const handleEndTimeChange = (newValue: Dayjs | null) => {
    setEndTime(newValue);
    if(allDay){
      setStartTime(null);
    }
  };

  const shouldDisableTime = (value: Dayjs, view: TimeView) => {
    if (view === 'hours') {
      const hour = value.hour();
      const minute = value.minute();
      if (hour >= 17 || hour < 7) {
        return true;
      }
      if (hour === 7 && minute < 30) {
        return true;
      }
    }
    return false;
  };



  const shouldDisableStartTime = (value: Dayjs, view: TimeView) => {
    if (view === 'hours') {
      const startHour = startTime?.hour();
      const startMinute = startTime?.minute();
      if (startHour !== undefined && startMinute !== undefined) {
        const startTime = dayjs()
          .set('hour', startHour)
          .set('minute', startMinute)
          .startOf('minute');
        const endTime = dayjs().set('hour', 16).startOf('hour');
        return (
          value.isBefore(startTime, 'hour') || value.isAfter(endTime, 'hour')
        );
      }
    }
    if (view === 'minutes') {
      const minute = value.minute();
      return minute !== 0 && minute !== 30;
    }
    return false;
  };
  const shouldDisableEndTime = (value: Dayjs, view: TimeView) => {
    if (view === 'hours') {
      const startHour = startTime?.add(1,'hour').hour();
      const startMinute = startTime?.minute();
      if (startHour !== undefined && startMinute !== undefined) {
        const startTime = dayjs()
          .set('hour', startHour)
          .set('minute', startMinute)
          .startOf('minute');

        const endTime = dayjs().set('hour', 16).startOf('hour'); 
        return (
          value.isBefore(startTime, 'hour') || value.isAfter(endTime, 'hour')
        );
      }
    }
    if (view === 'minutes') {
      const minute = value.minute();
      return minute !== 0 && minute !== 30;
    }
    return false;
  };

  
  return (
    <ThemeProvider theme={theme}>
      <Box
        sx={{
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
          justifyContent: 'center',
          
        }}
      >


 <AppBar position="static" sx={{ width: '100%' }}>
        <Toolbar sx={{ justifyContent: 'space-between' }}>
          <Typography variant="h6" component="div" >
            Reserve a desk
          </Typography>
        </Toolbar>
      </AppBar>

        <Box
          sx={{
            display: 'flex',
            justifyContent: 'space-between',
            alignItems: 'center',
            width: '100%',
            p:2,
            mb:2,    
          }}
          >
          <div></div>
          <Box
          sx={{
            display: 'flex',
            justifyContent: 'space-between',
            alignItems: 'center',
            width: '100%',
            p:2,
            mb:2,    
          }}></Box>
          <Box sx={{ justifyContent: 'flex-start', mt: 2 }}>
          <Button variant="contained"  
          size="large" 
          color="secondary" 
          sx={{ height: '50px', color: 'white', textTransform: 'none' }}>
            Save
          </Button>
          </Box>
          </Box>
         
     
        <DatePickerValue />
         
         <div>
          <Box sx={{ display: 'flex', mb: 2 }}>
          <DemoItem component="TimePicker">
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <div style={{ display: 'flex', alignItems: 'center' }}>
            <>
                <TimePicker
                label="Start"   
                onChange={handleStartTimeChange}
                shouldDisableTime={shouldDisableStartTime}
                  sx={{
                    '& .MuiOutlinedInput-root': {
                      borderColor: grey[900],
                      width: '18ch',
                    },
                    '& .MuiOutlinedInput-notchedOutline': {
                      borderColor: grey[900],
                      
                    },
                    '& .MuiOutlinedInput-input': {
                      color: grey[900],
                    },
                  }}
                />
                <Typography
                  variant="body1"
                  component="span"
                  style={{ margin: '0 10px' }}
                  
                >
                  to
                </Typography>
                <TimePicker
                 label="End"    
                 onChange={handleEndTimeChange}
                 shouldDisableTime={shouldDisableEndTime}
                  sx={{
                    '& .MuiOutlinedInput-root': {
                      borderColor: grey[900],
                      width: '18ch',
                    },
                    '& .MuiOutlinedInput-notchedOutline': {
                      borderColor: grey[900],
                    },
                    '& .MuiOutlinedInput-input': {
                      color: grey[900],
                    },
                  }}
                />
                
              </>
              
              </div>
            </LocalizationProvider>
          </DemoItem>
          </Box>
          </div>
          <BasicSelect />
        </Box>
      
    </ThemeProvider>
  );
}

export default ReserveDesk;