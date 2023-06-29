import { Typography, Link, Container, CssBaseline } from "@mui/material";
import { AppBar, Toolbar, Button, Box } from "@mui/material";
import LogoutIcon from '@mui/icons-material/Logout';
import { createTheme, ThemeProvider } from '@mui/material/styles';


function Copyright(props: any) {
    return (
      <Typography
        variant="body2"
        color="text.secondary"
        align="center"
        {...props}
      >
        {"Copyright © "}
        <Link color="inherit" href="https://mui.com/">
          Your Website
        </Link>{" "}
        {new Date().getFullYear()}
        {"."}
      </Typography>
    );
  }



  export default function Header() {
   
    const displayHeader = () => {
        return <Toolbar>
            <Typography sx={{marginLeft: 155}}>Name</Typography>
            {logout()}
        </Toolbar>;
    };
    const logout =() => {
        return <Button 
        variant="contained" color="primary"
        sx={{marginLeft: "auto", backgroundColor: "#2929ff"}}
        >Logout <LogoutIcon sx={{padding: "4px"}}></LogoutIcon></Button>
      
    }

    

    

    const defaultTheme = createTheme();

  return (
    <>
    <ThemeProvider theme={defaultTheme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
    <header >
        
        <AppBar sx={{position: "fixed", top: "0s"}}> {displayHeader()}</AppBar>
    </header>
    <Box
    margin={1}
    display="flex"
    justifyContent="flex-end" alignItems="flex-end"
    sx={{top: 100,
        right: "60%",
        marginRight: -100,
        position: "absolute",
       
    }}
    >
    <Button variant="contained" color="primary" 
    sx={{ mt: 3, mb: 2, backgroundColor: "#2929ff"}}
    >Make a reservation</Button>
    </Box>


    <Copyright sx={{ mt: 5, mb: 4, position:"absolute",
         left:0,
         bottom:0,
         right:0,}} />
         </Container>
        </ThemeProvider>
    </>
  );
}