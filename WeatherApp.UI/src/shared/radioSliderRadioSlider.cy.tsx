import React from 'react'
import { RadioSlider } from './radioSlider'

describe('<RadioSlider />', () => {
  it('renders a name = Radio Slider Test and initial value = 0', () => {
    // see: https://on.cypress.io/mounting-react
    cy.mount(<RadioSlider name='Radio Slider Test' value={5} setValue={() => { }} />)
    cy.get('input').should('have.value', 5)
  })
})