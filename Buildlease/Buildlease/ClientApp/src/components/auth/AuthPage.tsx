import { useState } from "react";
import { Redirect } from "react-router-dom";
import API from "../../API";

export default function AuthPage() {

  const [OK, setOK] = useState<boolean>(false);

  const [login, setLogin] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [restoreCode, setRestoreCode] = useState<string>('');

  async function TryLogin() {
    await API.Login(login, password)
      .then(() => setOK(true))
      .catch((e) => alert(e.response.data))
  }

  async function TryRegister() {
    await API.Register(login, password)
      .then(() => TryLogin())
      .catch((e) => alert(e.response.data))
  }

  async function TrySendRestoreCode() {
    await API.SendRestoreCode(login)
      .then(() => alert('Check your email!'))
      .catch((e) => alert(e.response.data))
  }

  async function TryChangePassword() {
    await API.ChangePassword(login, restoreCode, password)
      .then(() => TryLogin())
      .catch((e) => alert(e.response.data))
  }

  return (
    <>
    {OK && <Redirect to='/profile' />}
    <div style={{ width: 200, height: 300, display: 'flex', flexDirection: 'column', justifyContent: 'space-evenly', alignSelf: 'center'}}>
      <input placeholder='Email' type='email' value={login} onChange={e => setLogin(e.target.value)} />
      <input placeholder='Password' type='password' value={password} onChange={e => setPassword(e.target.value)} />
      <button onClick={TryRegister}>Sign up</button>
      <button onClick={TryLogin}>Sign in</button>
      <button onClick={TrySendRestoreCode}>Send restore code</button>
      <input placeholder='Restore code' value={restoreCode} onChange={e => setRestoreCode(e.target.value)} />
      <button onClick={TryChangePassword}>Change password</button>
    </div>
    </>
  );
}