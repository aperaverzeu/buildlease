import { useState } from 'react';

export default function Test() {

  const [name, setName] = useState<string>("Неизвестный");

  return (
    <div>
      <h6>Ты кто?</h6>
      <input type="text" value={name} onChange={(event) => setName(event.target.value)} />
      <h1>Привет, {name}!</h1>
    </div>
  );
}