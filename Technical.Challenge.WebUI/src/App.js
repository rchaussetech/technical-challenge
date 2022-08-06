import 'bulma/css/bulma.min.css'
import { useState } from 'react'
import {
  Box,
  Button,
  Columns,
  Container,
  Form,
  Section,
  Table,
} from 'react-bulma-components'

const RESULT_EMPTY = {
  input: 0,
  numbers: [],
}

function App() {
  const [loading, setLoading] = useState(false)
  const [inputNumber, setInputNumber] = useState('')
  const [result, setResult] = useState(RESULT_EMPTY)

  const inputNumberHandler = (e) => {
    setInputNumber(e.target.value)
  }

  const decomposeNumbersHandler = async () => {
    setLoading(true)
    const response = await fetch("https://localhost:5000/api/DecomposeNumber", {
      method: 'POST',
      body: JSON.stringify({
        number: Number(inputNumber)
      }),
      headers: new Headers({
        "content-type": "application/json",
      })
    }).then(res => {
      return res.ok ? res.json() : res
    })
      .catch(error => console.log('error', error))
      .finally(() => setLoading(false))

    if (Number.isInteger(response.status) && response.status !== 200) {
      const errorMessage = await response.text()
      alert(errorMessage)
      return
    }

    setResult(response)
  }

  const primeNumbersHandler = async () => {
    setLoading(true)
    const response = await fetch("https://localhost:5000/api/PrimeNumber", {
      method: 'POST',
      body: JSON.stringify({
        number: Number(inputNumber)
      }),
      headers: new Headers({
        "content-type": "application/json",
      })
    }).then(res => {
      return res.ok ? res.json() : res
    })
      .catch(error => console.log('error', error))
      .finally(() => setLoading(false))

    if (Number.isInteger(response.status) && response.status !== 200) {
      const errorMessage = await response.text()
      alert(errorMessage)
      return
    }

    setResult(response)
  }

  const cleanHanlder = () => {
    setInputNumber('')
    setResult(RESULT_EMPTY)
  }

  const linhasHtmlRender = () => {
    return result.numbers.map(number => (
      <tr key={number}>
        <td>{number}</td>
      </tr>
    ))
  }

  return (
    <Section>
      <Container>
        <h2 className="subtitle">
          Informe um número a ser decomposto
        </h2>
        <Columns>
          <Columns.Column>
            <Form.Field>
              <Form.Control>
                <Form.Input
                  type="Number"
                  placeholder="Number"
                  name="number"
                  value={inputNumber}
                  onChange={inputNumberHandler}
                />
              </Form.Control>
            </Form.Field></Columns.Column>
          <Columns.Column>
            <Button
              color="primary"
              fullwidth
              disabled={!inputNumber}
              loading={loading}
              onClick={decomposeNumbersHandler}>
              Divisores
            </Button>
          </Columns.Column>
          <Columns.Column>
            <Button
              color="info"
              fullwidth
              disabled={!inputNumber}
              loading={loading}
              onClick={primeNumbersHandler}>
              Números Primos
            </Button>
          </Columns.Column>
          <Columns.Column>
            <Button
              color="danger"
              fullwidth
              outlined
              loading={loading}
              onClick={cleanHanlder}>
              Limpar
            </Button>
          </Columns.Column>
        </Columns>
        <Box>
          <Table size="fullwidth">
            <thead>
              <tr>
                <th>
                  Números
                </th>
              </tr>
            </thead>
            <tbody>
              {linhasHtmlRender()}
            </tbody>
          </Table>
        </Box>
      </Container>
    </Section>
  )
}

export default App
