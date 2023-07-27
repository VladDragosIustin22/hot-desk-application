import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import Menu from "@mui/material/Menu";
import Avatar from "@mui/material/Avatar";
import Tooltip from "@mui/material/Tooltip";
import MenuItem from "@mui/material/MenuItem";
import TodayIcon from "@mui/icons-material/Today";
import { Link } from "react-router-dom";
import { Button, Stack, Divider } from "@mui/material";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import CreateIcon from "@mui/icons-material/Create";
import DeleteIcon from "@mui/icons-material/Delete";
import Modal from "@mui/material/Modal";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import EditReservation from "./edit-reservation";
import Logout from "./logout";
import jwt_decode from 'jwt-decode';
import { Reservation } from '../models/reservation';
import { MyProfile } from "../models/my-profile";


const settings = ["My Profile", "Settings"];

const style = {
  position: "absolute" as "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 1000,
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
};

function ReservationOverview() {
  const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(
    null
  );
  const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(
    null
  );

  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };
  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const [openDelete, setOpenDelete] = React.useState(false);
  const [openEdit, setOpenEdit] = React.useState(false);
  const handleOpenDelete = () => setOpenDelete(true);
  const handleCloseDelete = () => setOpenDelete(false);
  const handleOpenEdit = () => {
    setOpenEdit(true);
  };
  const handleCloseEdit = () => setOpenEdit(false);
  const [confirmation, setConfirmation] = useState(false);
  const navigate = useNavigate();
  const { id } = useParams();
  const handleNo = () => {
    setConfirmation(false);
    setOpenDelete(false);
    setOpenEdit(false);
    navigate("/reservationoverview");
  };
  const handleYes = () => {
    setConfirmation(true);
    setOpenDelete(false);
    setOpenEdit(false);
    navigate("/reservationoverview");
  };


 
 

const [reservation, setReservation] = useState<Reservation[] | null>(null);
const [Email, setEmail] = useState();
const [token, setToken] = useState("");
const [profile, setProfile] = useState<MyProfile[] | null>(null);
const [profileID, setProfileID] = useState("");

 useEffect(() =>{
    fetch(` https://localhost:7156/api/Reservation/GetAllProfileReservations/ ${Email}`)
    .then((response) =>response.json())
    .then(res => {
      const token = res.token;
      const reservationEmail = jwt_decode(token);
      localStorage.setItem('token', token );
      setToken(token); 
      setReservation(res);
    }).catch(err =>{
      alert("Error!");
    })
  },[]);
  

  return (
    <>
      <AppBar position="fixed">
        <Modal
          open={openEdit}
          onClose={handleCloseEdit}
          aria-labelledby="modal-modal-title"
        >
          <Box sx={style}>
            <EditReservation />
          </Box>
        </Modal>

        <Toolbar disableGutters>
          <TodayIcon
            sx={{
              display: { xs: "none", md: "flex" },
              mr: 1,
              fontSize: 40,
              marginLeft: 5,
            }}
          />{" "}
          <Typography
            variant="h4"
            noWrap
            component="a"
            sx={{
              mr: 2,
              display: { xs: "none", md: "flex" },
              fontFamily: "roboto",
              fontWeight: 700,
              letterSpacing: ".1rem",
              color: "inherit",
              textDecoration: "none",
            }}
          >
            My Reservations
          </Typography>
          <TodayIcon
            sx={{ display: { xs: "flex", md: "none" }, mr: 1, fontSize: 40 }}
          />
          <Typography
            variant="h5"
            noWrap
            component="a"
            sx={{
              mr: 2,
              display: { xs: "flex", md: "none" },
              flexGrow: 1,
              fontFamily: "roboto",
              fontWeight: 700,
              letterSpacing: ".3rem",
              color: "inherit",
              textDecoration: "none",
            }}
          >
            My Reservations
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: "flex", md: "flex" } }}></Box>
          <Box sx={{ flexGrow: 0, marginRight: 10 }}>
            <Stack direction="row" spacing={2} alignItems="center">
              <Tooltip title="Open settings">
                <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                  <MoreVertIcon sx={{ fontSize: 30 }}></MoreVertIcon>
                </IconButton>
              </Tooltip>

              <Avatar
                alt="User Name"
                src="https://mui.com/static/images/avatar/1.jpg"
                sx={{ marginLeft: 5, marginRight: -6 }}
              />

              <Typography
                variant="h6"
                noWrap
                sx={{
                  mr: 2,
                  display: { xs: "none", md: "flex" },
                  fontFamily: "roboto",
                  fontWeight: 700,
                  letterSpacing: ".0rem",
                  color: "#FFFFFF",
                  textDecoration: "none",
                  marginLeft: 2,
                  marginTop: 0,
                  padding: 1,
                }}
              >
                User Name
              </Typography>
            </Stack>
            <Box
              margin={1}
              display="flex"
              justifyContent="flex-end"
              alignItems="flex-end"
              sx={{
                top: 100,
                right: "60%",
                marginRight: -100,
                position: "absolute",
              }}
            >
              <Button sx={{ mt: 3, mb: 2, backgroundColor: "#EC7329" }}>
                <Link
                  style={{ textDecoration: "none" }}
                  to={"/reserve-a-desk"}
                  color="#FFFFFF"
                >
                  Make a reservation
                </Link>
              </Button>
            </Box>

            <Menu
              sx={{ mt: "45px" }}
              id="menu-appbar"
              anchorEl={anchorElUser}
              anchorOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
              open={Boolean(anchorElUser)}
              onClose={handleCloseUserMenu}
            >
              {settings.map((setting) => (
                <MenuItem key={setting} onClick={handleCloseUserMenu}>
                  <Typography textAlign="center">{setting}</Typography>
                </MenuItem>
              ))}
              <MenuItem>
                <Link onClick={Logout} color="black" to={"/login"} style={{ textDecoration: "none" }} >
                  Logout
                </Link>
              </MenuItem>
            </Menu>
          </Box>
        </Toolbar>
      </AppBar>
    
      <Box sx={{ flexGrow: 1, marginTop: 35, marginLeft: 20 }}>
        <Stack 
        //key ={reservations.profileEmail}
          direction="row"
          spacing={2}
          divider={<Divider orientation="vertical" flexItem />}
        >
          <Stack direction="row" alignItems="center" spacing={2}>
            <Avatar alt="Remy Sharp" src="https://mui.com/static/images/avatar/1.jpg" />
            <Stack direction="column">
           
              <Typography variant="h6" marginRight={60} alignItems="center" >
                Vlad Dragos
              </Typography>
          
              <Typography 
                variant="h6"
                sx={{
                  fontSize: 13,
                  marginRight: 72,
                }}
              >
               Developer
              </Typography>
            
            </Stack>
          </Stack>
          <Stack direction="row" alignItems="center" spacing={15}>
            <Stack direction="column" gap={2}>
              <Typography variant="h6" sx={{ fontSize: 15, marginTop: 2 }}>
             {/*}  {reservations.arrivalTime} */} 8:45
             {}
              </Typography>
              <Typography variant="h6" sx={{ fontSize: 15, marginTop: 2 }}>
                Office: Brizei
              </Typography>
            </Stack>
            <Stack direction="column" gap={2}>
              <Typography variant="h6" sx={{ fontSize: 15, marginTop: 2 }}>
                Interval: All day
              </Typography>
              <Typography
                variant="h6"
                sx={{
                  fontSize: 15,
                  marginTop: 2,
                }}
              >
                Floor: 1
              </Typography>
            </Stack>
            <Stack direction="column" alignItems="center" gap={2}>
              <Typography
                variant="h6"
                sx={{ fontSize: 15, marginTop: 2 }}
              ></Typography>
              <Typography
                variant="h6"
                sx={{
                  fontSize: 15,
                  marginTop: 5,
                }}
              >
                Desk: 2
              </Typography>
            </Stack>
            <Stack direction="column" alignItems="center" gap={3}>
              <Button onClick={handleOpenEdit}>
                <CreateIcon
                  sx={{
                    marginTop: 2,
                    fontSize: 18,
                  }}
                ></CreateIcon>
              </Button>

              <Button onClick={handleOpenDelete}>
                <DeleteIcon
                  sx={{
                    fontSize: 18,
                  }}
                ></DeleteIcon>
              </Button>
              <Modal
                open={openDelete}
                onClose={handleCloseDelete}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
              >
                <Box sx={style}>
                  <Typography
                    id="modal-modal-title"
                    variant="h5"
                    component="h2"
                  >
                    My Reservations
                  </Typography>
                  <Typography id="modal-modal-description" sx={{ mt: 2 }}>
                    Are you sure you want to delete this record?
                  </Typography>
                  <Box sx={{ marginTop: 2, marginLeft: 105 }}>
                    <Button onClick={handleNo}>Cancel</Button>
                    <Button onClick={handleYes}>Confirm</Button>
                  </Box>
                </Box>
              </Modal>
            </Stack>
          </Stack>
        </Stack>
      </Box>

    </>
  );
}
export default ReservationOverview;
