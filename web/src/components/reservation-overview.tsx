import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import Menu from "@mui/material/Menu";
import Container from "@mui/material/Container";
import Avatar from "@mui/material/Avatar";
import Tooltip from "@mui/material/Tooltip";
import MenuItem from "@mui/material/MenuItem";
import TodayIcon from "@mui/icons-material/Today";
import { Form, Link } from "react-router-dom";
import { Button, Stack, TextField, Grid } from "@mui/material";
import { styled } from "@mui/material/styles";
import Paper from "@mui/material/Paper";

const settings = ["My Profile", "Settings", "Logout"];
const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#fff",
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: "center",
  color: theme.palette.text.secondary,
}));
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
            <Stack direction="row" spacing={2}>
              <Tooltip title="Open settings">
                <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                  <Avatar
                    alt="Vlad Dragos-Iustin"
                    src="/static/images/avatar/2.jpg"
                  />
                </IconButton>
              </Tooltip>

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
      <Box
        sx={{
          flexGrow: 1,
          marginTop: 30,
          marginLeft: 30,
          display: { xs: "flex", md: "flex" },
        }}
      >
        <Grid container spacing={2}>
          <Grid
            item
            xs={6}
            justifyContent="center"
            direction="row"
            alignItems="center"
          >
            <Item>
              <Avatar alt="Remy Sharp" src="/static/images/avatar/1.jpg" />
              <Typography sx={{ marginRight: 70 }}>
                Vlad Dragos-Iustin
              </Typography>
            </Item>
          </Grid>

          <Grid item xs={4} marginRight={0}>
            <Item>xs=4</Item>
          </Grid>
        </Grid>
      </Box>
    </>
  );
}
export default ReservationOverview;
