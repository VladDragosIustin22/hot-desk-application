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
import { Form, Link } from "react-router-dom";
import { Button, Stack, TextField, Grid, Divider } from "@mui/material";
import { styled, createTheme, ThemeProvider } from "@mui/material/styles";
import Paper from "@mui/material/Paper";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import CreateIcon from "@mui/icons-material/Create";
import DeleteIcon from "@mui/icons-material/Delete";

const settings = ["My Profile", "Settings", "Logout"];

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
  return (
    <>
      <AppBar position="fixed">
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
                src="/static/images/avatar/1.jpg"
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
            </Menu>
          </Box>
        </Toolbar>
      </AppBar>
      <Box sx={{ flexGrow: 1, marginTop: 35, marginLeft: 20 }}>
        <Stack
          direction="row"
          spacing={2}
          divider={<Divider orientation="vertical" flexItem />}
        >
          <Stack direction="row" alignItems="center" spacing={2}>
            <Avatar alt="Remy Sharp" src="/static/images/avatar/1.jpg" />
            <Stack direction="column">
              <Typography variant="h6" marginRight={60} alignItems="center">
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
          <Stack direction="row" alignItems="center" spacing={10}>
            <Stack direction="column">
              <Typography variant="h6" sx={{ fontSize: 15, marginTop: 4 }}>
                Date: 05.07.2023
              </Typography>
              <Typography variant="h6" sx={{ fontSize: 15, marginTop: 4 }}>
                Office: Brizei
              </Typography>
            </Stack>
            <Stack direction="column">
              <Typography variant="h6" sx={{ fontSize: 15, marginTop: 4 }}>
                Interval: All day
              </Typography>
              <Typography
                variant="h6"
                sx={{
                  fontSize: 15,
                  marginTop: 4,
                }}
              >
                Floor: 1
              </Typography>
            </Stack>
            <Stack direction="column" alignItems="center">
              <Typography
                variant="h6"
                sx={{ fontSize: 15, marginTop: 4 }}
              ></Typography>
              <Typography
                variant="h6"
                sx={{
                  fontSize: 15,
                  marginTop: 8,
                }}
              >
                Desk: 2
              </Typography>
            </Stack>
            <Stack direction="column" alignItems="center" spacing={9}>
              <CreateIcon></CreateIcon>
              <DeleteIcon></DeleteIcon>
            </Stack>
          </Stack>
        </Stack>
      </Box>
    </>
  );
}
export default ReservationOverview;
