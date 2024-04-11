import React from 'react'
import { HomePage } from './homePage'
import AuthInfoProvider from '../state/authInfoContext'

describe('<HomePage />', () => {
  it('renders', () => {
    // see: https://on.cypress.io/mounting-react
    cy.mount(<AuthInfoProvider>
      <HomePage />
    </AuthInfoProvider>)
  })
})