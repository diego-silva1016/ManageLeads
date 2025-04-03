import { Tab, Container } from 'semantic-ui-react'

import InvitedList from './InvitedList'
import AcceptedList from './AcceptedList'

function LeadsDash() {
    const panes = [
        {
            menuItem: 'Invited',
            render: () => <InvitedList />,
        },
        {
            menuItem: 'Accepted',
            render: () => <AcceptedList />,
        }
    ]

    return (
        <div style={{ height: '100vh', backgroundColor: '#d3d1d1', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
            <Container style={{ height: '40rem', overflow: 'auto' }}>
                <Tab
                    menu={{
                        style: { background: '#fff' },
                        color: 'orange',
                        secondary: true,
                        pointing: true,
                        attached: false,
                        widths: 2
                    }}
                    panes={panes}
                />
            </Container>
        </div>
    )
}

export default LeadsDash
