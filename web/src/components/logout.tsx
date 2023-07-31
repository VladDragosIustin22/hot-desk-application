export default function Logout(){
    localStorage.removeItem('authToken');
    localStorage.removeItem('authTokenExpiry');
    localStorage.clear();
}